datablock AudioProfile(TF2GrenadeLauncherShootSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/grenade_launcher_shoot.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2GrenadeLauncherShootCritSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/grenade_launcher_shoot_crit.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2GrenadeLauncherImpact1Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/grenade_impact1.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2GrenadeLauncherImpact2Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/grenade_impact2.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2GrenadeLauncherImpact3Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/grenade_impact3.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock ParticleData(TF2GrenadeExplosionParticle)
{
  dragCoefficient  = 3.5;
  windCoefficient  = 3.5;
  gravityCoefficient  = -1;
  inheritedVelFactor  = 0.0;
  constantAcceleration  = 0.0;
  //lifetimeMS  = 800;
  lifetimeMS = 1100;
  lifetimeVarianceMS  = 00;
  spinSpeed  = 25.0;
  spinRandomMin  = -25.0;
  spinRandomMax  = 25.0;
  useInvAlpha  = false;
  animateTexture  = false;

  textureName  = "base/data/particles/cloud";

  colors[0]   = "1 1 1 0.1";
  colors[1]   = "0.9 0.5 0.0 0.3";
  colors[2]   = "0.1 0.05 0.025 0.1";
  colors[3]   = "0.1 0.05 0.025 0.0";

  sizes[0]  = 4.0;
  sizes[1]  = 6.3;
  sizes[2] = 6.5;
  sizes[3] = 4.5;

  times[0]  = 0.0;
  times[1]  = 0.1;
  times[2] = 0.8;
  times[3] = 1.0;
};

datablock ParticleEmitterData(TF2GrenadeExplosionEmitter)
{
  ejectionPeriodMS = 1;
  periodVarianceMS = 0;
  lifeTimeMS   = 21;
  ejectionVelocity = 4;
  velocityVariance = 3.0;
  ejectionOffset  = 2.0;
  thetaMin        = 00;
  thetaMax        = 180;
  phiReferenceVel  = 0;
  phiVariance     = 360;
  overrideAdvance = false;
  particles = TF2GrenadeExplosionParticle;
};

datablock ExplosionData(TF2GrenadeLauncherExplosion)
{
  emitter[0] = TF2GrenadeExplosionEmitter;

  faceViewer  = true;
  explosionScale = "1 1 1";

  shakeCamera = true;
  camShakeFreq = "10.0 11.0 10.0";
  camShakeAmp = "3.0 10.0 3.0";
  camShakeDuration = 0.5;
  camShakeRadius = 20.0;

  lightStartRadius = 10;
  lightEndRadius = 25;
  lightStartColor = "1 1 1 1";
  lightEndColor = "0 0 0 1";

  damageRadius = 144 * $HU_TO_TU;
  radiusDamage = 45;

  impulseRadius = 144 * $HU_TO_TU;
  impulseForce = 3000;
};

addDamageType("TF2GrenadeLauncher", '<bitmap:Add-Ons/Weapon_Package_TF2/images/CI_Grenade_Launcher> %1', '%2 <bitmap:Add-Ons/Weapon_Package_TF2/images/CI_Grenade_Launcher> %1', 1, 1);
$TF2Damage::IsValid[$DamageType::TF2GrenadeLauncher] = 1;

datablock ProjectileData(TF2GrenadeLauncherProjectile)
{
  projectileShapeName = "Add-Ons/Weapon_Rocket_Launcher/RocketProjectile.dts";
  directDamage     = 90;
  directDamageType = $DamageType::TF2GrenadeLauncher;
  radiusDamageType = $DamageType::TF2GrenadeLauncher;
  impactImpulse  = 800;
  verticalImpulse  = 950;
  explosion        = TF2GrenadeLauncherExplosion;
  //particleEmitter  = TF2GrenadeTrailEmitter;

  muzzleVelocity = 1217.5 * $HU_TO_TU;
  velInheritFactor = 0.1;
  explodeOnDeath = 1;

  armingDelay = 3500;
  lifeTime = 3500;
  fadeDelay = 3500;

  isBallistic = 1;
  gravityMod = 1;
  bounceElasticity = 0.65;
  bounceFriction = 0.3;

  hasLight = true;
  lightRadius = 5.0;
  lightColor  = "1 0.5 0.0";
};

datablock ProjectileData(TF2GrenadeLauncherCritREDProjectile : TF2GrenadeLauncherProjectile)
{
  //particleEmitter = TF2GrenadeTrailCritREDEmitter;
  foo = bar;
};

datablock ProjectileData(TF2GrenadeLauncherCritBLUProjectile : TF2GrenadeLauncherProjectile)
{
  //particleEmitter = TF2GrenadeTrailCritBLUEmitter;
  foo = bar;
};

datablock ItemData(TF2GrenadeLauncherItem)
{
  className = "Weapon";

  shapeFile = "Add-Ons/Weapon_Package_TF2/shapes/GrenadeLauncher.dts";
  emap = 1;
  mass = 1;
  density = 0.2;
  elasticity = 0.2;
  friction = 0.6;

  uiName = "Grenade Launcher";

  doColorShift = 1;
  colorShiftColor = 184 / 255 SPC 56 / 255 SPC 59 / 255 SPC 1;

  image = TF2GrenadeLauncherREDImage;
  canDrop = 1;
};

datablock ShapeBaseImageData(TF2GrenadeLauncherREDImage)
{
  className = "WeaponImage";
  useTF2Projectile = 1;

  shapeFile = "Add-Ons/Weapon_Package_TF2/shapes/GrenadeLauncher.dts";
  emap = 1;

  mountPoint = 0;
  correctMuzzleVector = 1;

  item = TF2GrenadeLauncherItem;

  projectile = TF2GrenadeLauncherProjectile;
  projectileCrit = TF2GrenadeLauncherCritREDProjectile;
  projectileType = Projectile;

  melee = 0;
  armReady = 1;
  minShotTime = 600;

  doColorShift = TF2GrenadeLauncherItem.doColorShift;
  colorShiftColor = TF2GrenadeLauncherItem.colorShiftColor;

  stateName[0]                  = "Activate";
  stateTimeoutValue[0]          = 0.25;
  stateTransitionOnTimeout[0]    = "Ready";
  stateSound[0]      = weaponSwitchSound;

  stateName[1]                  = "Ready";
  stateTransitionOnTriggerDown[1]  = "Fire";
  stateAllowImageChange[1]      = true;
  stateTransitionOnNoAmmo[1]    = "NoAmmo";
  stateSequence[1]  = "Ready";

  stateName[2]                 = "Fire";
  stateTransitionOnTimeout[2]  = "Smoke";
  stateTimeoutValue[2]         = 0.1;
  stateFire[2]                 = true;
  stateAllowImageChange[2]     = false;
  stateSequence[2]             = "Fire";
  stateScript[2]               = "onFire";
  stateWaitForTimeout[2]   = true;
  stateSequence[2]             = "Fire";

  stateName[3] = "Smoke";
  //stateEmitter[3]      = TF2GrenadeLauncherSmokeEmitter;
  stateEmitterTime[3]    = 0.05;
  stateEmitterNode[3]    = "muzzleNode";
  stateTimeoutValue[3]         = 0.1;
  stateSequence[3]             = "TrigDown";
  stateTransitionOnTimeout[3]  = "CoolDown";

  stateName[5] = "CoolDown";
  stateTimeoutValue[5]         = 0.5;
  stateTransitionOnTimeout[5]  = "Reload";
  stateSequence[5]             = "TrigDown";

  stateName[4]   = "Reload";
  stateTransitionOnTriggerUp[4]  = "Ready";
  stateSequence[4]  = "TrigDown";

  stateName[6]  = "NoAmmo";
  stateTransitionOnAmmo[6] = "Ready";
};

datablock ShapeBaseImageData(TF2GrenadeLauncherBLUImage : TF2GrenadeLauncherREDImage)
{
  projectileCrit = TF2GrenadeLauncherCritBLUProjectile;
  colorShiftColor = "0.345 0.521 0.635 1";
};

function TF2GrenadeLauncherREDImage::onFire(%this, %obj, %slot)
{
  %p = Parent::onFire(%this, %obj, %slot);

  if (%p.crit == 2)
    %sound = TF2GrenadeLauncherShootCritSound;
  else
    %sound = TF2GrenadeLauncherShootSound;

  serverPlay3D(%sound, %obj.getMuzzlePoint(%slot));
  //%obj.playThread(0, "shiftUp");
  %obj.playThread(0, "jump");

  return %p;
}

function TF2GrenadeLauncherBLUImage::onFire(%this, %obj, %slot)
{
  return TF2GrenadeLauncherREDImage::onFire(%this, %obj, %slot);
}

function TF2GrenadeLauncherProjectile::onExplode(%this, %obj, %a, %b, %c, %d)
{
  %sound = nameToID("TF2Explode" @ getRandom(1, 3) @ "Sound");

  if (isObject(%sound))
    serverPlay3D(%sound, %obj.getPosition());

  Parent::onExplode(%this, %obj, %a, %b, %c, %d);
}


function TF2GrenadeLauncherProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal)
{
  if (%col.getType() & $TypeMasks::PlayerObjectType && !%obj.bounced)
  {
    if (miniGameCanDamage(%obj, %col))
      %this.damage(%obj, %col, %fade, %pos, %normal);

    %obj.explode();
  }
  else
  {
    %obj.bounced = 1;
    %sound = nameToID("TF2GrenadeLauncherImpact" @ getRandom(1, 3) @ "Sound");

    if (isObject(%sound))
      serverPlay3D(%sound, %pos);
  }

  Parent::onCollision(%this, %obj, %col, %fade, %pos, %normal);
}

function TF2GrenadeLauncherCritREDProjectile::onExplode(%this, %obj, %a, %b, %c, %d)
{
  TF2GrenadeLauncherProjectile::onExplode(%this, %obj, %a, %b, %c, %d);
}

function TF2GrenadeLauncherCritREDProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal)
{
  TF2GrenadeLauncherProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal);
}

function TF2GrenadeLauncherCritBLUProjectile::onExplode(%this, %obj, %a, %b, %c, %d)
{
  TF2GrenadeLauncherProjectile::onExplode(%this, %obj, %a, %b, %c, %d);
}

function TF2GrenadeLauncherCritBLUProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal)
{
  TF2GrenadeLauncherProjectile::onCollision(%this, %obj, %col, %fade, %pos, %normal);
}
