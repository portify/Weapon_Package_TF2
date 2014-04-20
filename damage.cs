datablock AudioProfile(TF2HitSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/ui/hitsound.wav";
  description = AudioQuiet2D;
  preload = 1;
};

package TF2DamagePackage
{
  function Armor::damage(%this, %obj, %source, %position, %damage, %type)
  {
    %crit = %obj.critHit;
    %obj.critHit = "";

    if (!$TF2Damage::IsValid[%type])
      return Parent::damage(%this, %obj, %source, %position, %damage, %type);

    if (%obj.getState() $= "Dead" || %damage <= 0)
      return;

    %obj.lastTF2DamageTime = $Sim::Time;
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

    %damage = %obj.calculateDamage(%player, %damage, %crit, $TF2Damage::NoRamp[%type]);

    if (%damage <= 0)
      return;

    if (isObject(%player) && %player != %obj)
      %player.addRecentDamage(%damage);

    if ($Sim::Time - %obj.lastCritEmote >= 0.1)
    {
      %db[2] = TF2CriticalHitProjectile;

      if (isObject(%db[%crit]))
      {
        %obj.emote(%db[%crit], 1);
        %obj.lastCritEmote = $Sim::Time;
      }
    }

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
    if (!%this.isTF2Projectile)
      return Parent::radiusDamage(%this, %obj, %col, %factor, %pos, %damage);

    if (%obj.directHit[%col])
      return;

    %factor *= calcExplosionCoverage(%pos, %obj, $TypeMasks::FxBrickObjectType);

    //if (%col == %obj.sourceObject)
    //  %factor /= 2;

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
    if (%this.isTF2Projectile)
    {
      if (%obj.directHit[%col])
        return;

      %factor *= calcExplosionCoverage(%pos, %obj, $TypeMasks::FxBrickObjectType);
    }

    Parent::radiusImpulse(%this, %obj, %col, %factor, %pos, %force);
  }
};

activatePackage("TF2DamagePackage");

function ShapeBase::calculateDamage(%this, %source, %damage, %crit, %noRamp)
{
  //%distance = vectorDist(%this.position, %source.position) * 20;
  if (%this == %source)
    %distance = 768;
  else
    %distance = vectorDist(%this.position, %source.position) * $TU_TO_HU;

  %recentDamage = %source.recentDamage;

  //%minFalloff = 0;
  %minFalloff = 512;
  %maxFalloff = 1024;

  %crit = mClamp(%crit, 0, 2);

  if (%crit != 2 && !%noRamp)
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
