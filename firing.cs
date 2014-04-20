package TF2ProjectilePackage
{
  function WeaponImage::onFire(%this, %obj, %slot)
  {
    if (!%this.useTF2Projectile)
      return Parent::onFire(%this, %obj, %slot);

    %obj.hasShotOnce = 1;

    if (%this.minShotTime > 1)
    {
      if (getSimTime() - %obj.lastFireTime < %this.minShotTime)
        return;

      %obj.lastFireTime = getSimTime();
    }

    %crit = %obj.rollCritical();
    %projectile = %this.projectile;

    if (isObject(%this.projectileCrit) && %crit == 2)
      %projectile = %this.projectileCrit;

    if (!isObject(%projectile))
      return;

    %muzzlePoint = %obj.getMuzzlePoint(%slot);
    %muzzleVector = %obj.getMuzzleVector(%slot);

    %inherit = %projectile.inheritFactor;
    %dot = vectorDot(%obj.getEyeVector(), %muzzleVector);

    if (%dot < 0.6 && vectorLen(%obj.getVelocity()) < 14)
      %inherit = 0;

    %velocity = vectorScale(%muzzleVector, %projectile.muzzleVelocity);
    %velocity = vectorAdd(%velocity, vectorScale(%obj.getVelocity(), %inherit));

    %p = new Projectile()
    {
      dataBlock = %projectile;

      initialPosition = %muzzlePoint;
      initialVelocity = %velocity;

      sourceObject = %obj;
      sourceSlot = %slot;

      client = %obj.client;
      crit = %crit;
    };

    MissionCleanup.add(%p);
    return %p;
  }
};

activatePackage("TF2ProjectilePackage");

package TF2RaycastPackage
{
  function WeaponImage::onFire(%this, %obj, %slot)
  {
    if (!%this.useTF2Raycast)
      return Parent::onFire(%this, %obj, %slot);

    if (%this.raycastRange <= 0)
      return 0;

    if (%obj.lastShot[%this] + %this.minShotTime > getSimTime())
      return 0;

    %obj.lastShot[%this] = getSimTime();

    if (%this.raycastMask $= "")
      %mask =
        $TypeMasks::PlayerObjectType |
        $TypeMasks::TerrainObjectType |
        $TypeMasks::FxBrickObjectType |
        $TypeMasks::VehicleObjectType |
        $TypeMasks::StaticShapeObjectType;
    else
      %mask = %this.raycastMask;

    %crit = %obj.rollCritical(%this.raycastMelee);
    %eyePoint = %obj.getEyePoint();

    %basePoint = %obj.getMuzzlePoint(%slot);
    %baseVector = %obj.getMuzzleVector(%slot);

    %ray = containerRayCast(%eyePoint, %basePoint, %mask, %obj);

    if (%ray)
    {
      %pos = getWords(%ray, 1, 3);

      %basePoint = %eyePoint;
      %baseVector = vectorNormalize(vectorSub(%pos, %eyePoint));
    }

    %count = 1;

    if (%this.raycastMinCount !$= "" && %this.raycastMaxCount !$= "")
      %count = getRandom(%this.raycastMinCount, %this.raycastMaxCount);
    else if (%this.raycastCount !$= "")
      %count = %this.raycastCount;

    for (%i = 0; %i < %count; %i++)
    {
      %spread = %this.getRaycastSpread(%obj, %slot, %i);

      if (%spread $= "0 0 0")
        %vector = %baseVector;
      else
      {
        %matrix = matrixCreateFromEuler(%spread);
        %vector = matrixMulVector(%matrix, %baseVector);
      }

      %vec = vectorScale(%vector, %this.raycastRange);
      %end = vectorAdd(%basePoint, %vec);

      %ray = containerRayCast(%basePoint, %end, %mask, %obj);

      if (%ray)
      {
        %b = getWords(%ray, 1, 3);
        %this.onRaycastCollision(%obj, getWord(%ray, 0), %b, getWords(%ray, 4, 6), %vector, %crit);
      }
      else
      {
        %b = %end;
        %this.onRaycastMissed(%obj, %end, %vector);
      }

      if (isObject(%this.raycastTracer))
        createTracer(%basePoint, %b, %this.raycastTracer, %this.raycastTracerSize, %this.raycastTracerColor);
    }

    return %crit;
  }
};

activatePackage("TF2RaycastPackage");

function getRandomScalar()
{
  return getRandom() * 2 - 1;
}

function SimObject::hasMethod(%this, %name)
{
  return (
    isFunction(%this.class, %name) ||
    isFunction(%this.getName(), %name) ||
    isFunction(%this.getClassName(), %name)
  );
}

function WeaponImage::getRaycastSpread(%this, %obj, %slot, %index)
{
  if (%this.raycastSpread !$= "" && %index >= %this.raycastSpreadExempt)
  {
    %scalars = getRandomScalar() SPC getRandomScalar() SPC getRandomScalar();
    return vectorScale(%scalars, mDegToRad(%this.raycastSpread / 2));
  }

  return "0 0 0";
}

function WeaponImage::onRaycastCollision(%this, %obj, %col, %pos, %normal, %vec, %crit)
{
  if (isObject(%this.raycastHitExplosion))
  {
    %explosion = new Projectile()
    {
      datablock = %this.raycastHitExplosion;

      initialPosition = %pos;
      initialVelocity = 0;
    };

    MissionCleanup.add(%explosion);

    %explosion.setScale(%obj.getScale());
    %explosion.explode();
  }

  if (%col.getType() & ($TypeMasks::PlayerObjectType | $TypeMasks::VehicleObjectType))
  {
    if (isObject(%col.spawnBrick) && %col.spawnBrick.getGroup().client == %obj.client)
      %spawned = 1;

    if (miniGameCanDamage(%obj, %col) == 1 || %spawned)
      %this.damage(%obj, %col, %pos, %normal, %vec, %crit);
  }
}

function WeaponImage::onRaycastMissed(%this, %obj, %pos, %vec)
{
}

function WeaponImage::damage(%this, %obj, %col, %pos, %normal, %vec, %crit)
{
  if (%this.directDamage <= 0)
    return;

  %type = $DamageType::Direct;

  if (%this.directDamageType)
    %type = %this.directDamageType;

  %col.critHit = %crit;
  %col.damage(%obj, %pos, %this.directDamage, %type);

  if (%this.raycastImpactImpulse)
    %col.applyImpulse(%pos, vectorScale(%vec, %this.impactImpulse));

  if (%this.raycastVerticalImpulse)
    %col.applyImpulse(%pos, vectorScale("0 0 1", %this.verticalImpulse));
}
