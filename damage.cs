datablock AudioProfile(TF2HitSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/ui/hitsound.wav";
  description = AudioQuiet2D;
  preload = 1;
};

datablock AudioProfile(TF2CritHit1Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/player/crit_hit.wav";
  description = AudioLoud2D;
  preload = 1;
};

datablock AudioProfile(TF2CritHit2Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/player/crit_hit2.wav";
  description = AudioLoud2D;
  preload = 1;
};

datablock AudioProfile(TF2CritHit3Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/player/crit_hit3.wav";
  description = AudioLoud2D;
  preload = 1;
};

datablock AudioProfile(TF2CritHit4Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/player/crit_hit4.wav";
  description = AudioLoud2D;
  preload = 1;
};

datablock AudioProfile(TF2CritHit5Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/player/crit_hit5.wav";
  description = AudioLoud2D;
  preload = 1;
};

datablock AudioProfile(TF2CritHitMini1Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/player/crit_hit_mini.wav";
  description = AudioLoud2D;
  preload = 1;
};

datablock AudioProfile(TF2CritHitMini2Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/player/crit_hit_mini2.wav";
  description = AudioLoud2D;
  preload = 1;
};

datablock AudioProfile(TF2CritHitMini3Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/player/crit_hit_mini3.wav";
  description = AudioLoud2D;
  preload = 1;
};

datablock AudioProfile(TF2CritHitMini4Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/player/crit_hit_mini4.wav";
  description = AudioLoud2D;
  preload = 1;
};

datablock AudioProfile(TF2CritHitMini5Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/player/crit_hit_mini5.wav";
  description = AudioLoud2D;
  preload = 1;
};

datablock AudioProfile(TF2CritReceived1Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/player/crit_received1.wav";
  description = AudioLoud2D;
  preload = 1;
};

datablock AudioProfile(TF2CritReceived2Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/player/crit_received2.wav";
  description = AudioLoud2D;
  preload = 1;
};

datablock AudioProfile(TF2CritReceived3Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/player/crit_received3.wav";
  description = AudioLoud2D;
  preload = 1;
};

package TF2DamagePackage
{
  function Armor::damage(%this, %obj, %source, %position, %damage, %type, %crit)
  {
    %obj.lastTF2DamageTime = $Sim::Time;

    if (!$TF2Damage::IsValid[%type])
      return Parent::damage(%this, %obj, %source, %position, %damage, %type);

    if (%obj.getState() $= "Dead" || %damage <= 0)
      return;

    %crit = %obj.critHit;
    %obj.critHit = "";

    %player = 0;

    if (isObject(%source))
    {
      %mask = %source.getType();

      if (%source.getClassName() $= "GameConnection")
        %player = %source.player;
      if (%mask & $TypeMasks::PlayerObjectType)
        %player = %source;
      else if (%mask & $TypeMasks::ProjectileObjectType)
        %player = %source.sourceObject;
    }

    if (!isObject(%player))
      %player = %obj;

    %damage = %obj.calculateDamage(%player, %damage, $TF2Damage::IsMelee[%type], %crit);

    if (%damage <= 0)
      return;

    if (isObject(%player) && %player != %obj)
      %player.addRecentDamage(%damage);

    if (isObject(%obj.client) && %crit == 2)
    {
      %sound = nameToID("TF2CritReceived" @ getRandom(1, 3) @ "Sound");

      if (isObject(%sound))
        %obj.client.play2D(%sound);
    }

    if (isObject(%source.client) && %player != %obj)
    {
      if (%crit == 1)
        %sound = "TF2CritHitMini" @ getRandom(1, 5) @ "Sound";
      else if (%crit == 2)
        %sound = "TF2CritHit" @ getRandom(1, 5) @ "Sound";
      else
        %sound = "TF2HitSound";

      if (isObject(%sound))
        %source.client.play2D(%sound);
    }

    Parent::damage(%this, %obj, %source, %position, %damage, %type);
  }

  function ProjectileData::damage(%this, %obj, %col, %fade, %pos, %normal)
  {
    //if (!%this.isTF2Projectile)
    if (0)
      return Parent::damage(%this, %obj, %col, %fade, %pos, %normal);

    %obj.directHit[%col] = 1;

    if (%this.directDamage <= 0)
      return;

    %type = $DamageType::Direct;

    if (%this.directDamageType)
      %type = %this.directDamageType;

    %col.critHit = %obj.crit;
    %col.damage(%obj, %pos, %this.directDamage, %type);
  }

  function ProjectileData::radiusDamage(%this, %obj, %col, %factor, %pos, %damage)
  {
    //if (!%this.isTF2Projectile)
    if (0)
      return Parent::radiusDamage(%this, %obj, %col, %factor, %pos, %damage);

    if (%obj.directHit[%col])
      return;

    %factor *= calcExplosionCoverage(%pos, %obj, $TypeMasks::FxBrickObjectType);

    if (%col == %obj.sourceObject)
      %factor /= 2;

    %factor = mClampF(%factor, 0, 1);
    %damage *= %factor;
    %type = $DamageType::Radius;

    if (%this.radiusDamageType)
      %type = %this.radiusDamageType;

    %col.critHit = %obj.crit;
    %col.damage(%obj, %pos, %damage, %type);
  }

  function ProjectileData::radiusImpulse(%this, %obj, %col, %factor, %pos, %force)
  {
    //if (%this.isTF2Projectile)
    if (1)
    {
      if (%obj.directHit[%col])
        return;

      %factor *= calcExplosionCoverage(%pos, %obj, $TypeMasks::FxBrickObjectType);
    }

    Parent::radiusImpulse(%this, %obj, %col, %factor, %pos, %force);
  }

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

activatePackage("TF2DamagePackage");

function Player::rollCritical(%this, %melee)
{
  %chance = %melee ? 0.15 : 0.02;
  %chance += mClampF(%this.recentDamage / 800, 0, 1) * (%melee ? 0.45 : 0.1);

  %crit = getRandom() < %chance ? 2 : 0;
  %crit = mClamp(getMax(%crit, %this.critBoost), 0, 2);

  return %crit;
}

function ShapeBase::calculateDamage(%this, %source, %damage, %melee, %crit)
{
  //%distance = vectorDist(%this.position, %source.position) * 20;
  if (%this == %source)
    %distance = 512;
  else
    %distance = vectorDist(%this.position, %source.position) * $TU_TO_HU;

  %recentDamage = %source.recentDamage;

  //%minFalloff = 0;
  %minFalloff = 512;
  %maxFalloff = 1024;

  %crit = mClamp(%crit, 0, 2);

  if (%crit != 2)
  {
    // %midFalloff = (%maxFalloff + %minFalloff) / 2;

    // if (%crit == 1 && %distance > %midFalloff)
      // %distance = %midFalloff;
    if (%crit == 1 && %distance > %minFalloff)
      %distance = %minFalloff;

    %random = 0.925 + getRandom() * 0.075;
    // %distance = mClampF(%distance * %random, %minFalloff, %maxFalloff);
    %distance = mClampF(%distance * %random, 0, %maxFalloff);
    %base = %damage;

    %multiplier = %minFalloff / %maxFalloff;
    %falloff = %multiplier * %damage;
    %sinusoidal = (%falloff - %damage) / (%maxFalloff - %minFalloff);
    %intercept = %damage - %sinusoidal * %minFalloff;
    %damage = %sinusoidal * %distance + %intercept;

    //%multiplier = %minFalloff / %maxFalloff;
    //%falloff = %multiplier * %damage;
    //%sinusoidal = (%falloff - %damage) / (%maxFalloff - %minFalloff);
    //%intercept = %damage - %sinusoidal * %falloff;

    //announce("damage" SPC %damage SPC "at distance" SPC %distance SPC "turned into" SPC %sinusoidal * %distance + %intercept);
    //%damage = %sinusoidal * %distance + %intercept;
    // %factor = (%distance - %minFalloff) / (%maxFalloff - %minFalloff);
    // %factor = 0.5 + (1 - %factor);

    // %damage *= %factor;
  }

  %scale = (%crit == 2 ? 3 : (%crit == 1 ? 1.35 : 1));

  if (%source == %this)
    %scale = 1;

  return %damage * %scale;
}

function ShapeBase::addRecentDamage(%this, %damage)
{
  if (%damage < 0)
    return;

  %this.recentDamage += %damage;
  %this.schedule(20000, subtractRecentDamage, %damage);
}

function ShapeBase::subtractRecentDamage(%this, %damage)
{
  if (%damage < 0)
    return;

  %this.recentDamage -= %damage;

  if (%this.recentDamage < 0)
    %this.recentDamage = 0;
}
