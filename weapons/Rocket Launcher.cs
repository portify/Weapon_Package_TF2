datablock AudioProfile(TF2RocketLauncherShootSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/rocket_shoot.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2RocketLauncherShootCritSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/rocket_shoot_crit.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock ParticleData(TF2RocketLauncherSmokeParticle)
{
  dragCoefficient   = 0.4;
  gravityCoefficient  = 0;
  inheritedVelFactor  = 0.2;
  constantAcceleration = 0.0;
  lifetimeMS        = 1000;
  lifetimeVarianceMS  = 250;
  textureName       = "base/data/particles/cloud";
  spinSpeed  = 4.0;
  spinRandomMin  = -100.0;
  spinRandomMax  = 100.0;

  colors[0]  = "0.2 0.2 0.2 0.0";
  colors[1]  = "0.2 0.2 0.2 0.3";
  colors[2]  = "0.2 0.2 0.2 0.0";

  sizes[0]   = 0.75;
  sizes[1]   = 2;
  sizes[2]   = 2.5;

  times[0] = 0.0;
  times[1] = 0.2;
  times[2] = 1.0;

  useInvAlpha = false;
};
datablock ParticleEmitterData(TF2RocketLauncherSmokeEmitter)
{
  ejectionPeriodMS = 5;
  periodVarianceMS = 0;
  ejectionVelocity = 1.5;
  velocityVariance = 0.0;
  ejectionOffset  = 0.0;
  thetaMin      = 0;
  thetaMax      = 25;
  phiReferenceVel  = 0;
  phiVariance   = 360;
  overrideAdvance = false;
  particles = TF2RocketLauncherSmokeParticle;
};

datablock ParticleData(TF2RocketTrailParticle)
{
  dragCoefficient   = 3;
  gravityCoefficient  = -0.0;
  inheritedVelFactor  = 0.15;
  constantAcceleration = 0.0;
  //lifetimeMS        = 1000;
  lifetimeMS = 2000;
  lifetimeVarianceMS  = 805;
  textureName       = "base/data/particles/cloud";
  spinSpeed  = 10.0;
  spinRandomMin  = -150.0;
  spinRandomMax  = 150.0;
  colors[0]  = "1.0 1.0 0.0 0.4";
  colors[1]  = "1.0 0.2 0.0 0.5";
  colors[2]  = "0.20 0.20 0.20 0.3";
  colors[3]  = "0.0 0.0 0.0 0.0";

  sizes[0]   = 0.25;
  sizes[1]   = 0.85;
  sizes[2]   = 0.35;
  sizes[3]   = 0.05;

  times[0] = 0.0;
  times[1] = 0.05;
  times[2] = 0.3;
  times[3] = 1.0;

  useInvAlpha = false;
};

datablock ParticleEmitterData(TF2RocketTrailEmitter)
{
  ejectionPeriodMS = 5;
  periodVarianceMS = 1;
  ejectionVelocity = 0.25;
  velocityVariance = 0.0;
  ejectionOffset  = 0.0;
  thetaMin      = 0;
  thetaMax      = 90;
  phiReferenceVel  = 0;
  phiVariance   = 360;
  overrideAdvance = false;
  particles = TF2RocketTrailParticle;
};

datablock ParticleData(TF2RocketTrailCritREDParticle : TF2RocketTrailParticle)
{
  colors[0]  = "1 1 0 0.4";
  colors[1]  = "1 0 0 0.5";
  colors[2]  = "1 0 0.2 0.3";
  colors[3]  = "0 0 0 0";
};

datablock ParticleEmitterData(TF2RocketTrailCritREDEmitter : TF2RocketTrailEmitter)
{
  particles = TF2RocketTrailCritREDParticle;
};

datablock ParticleData(TF2RocketTrailCritBLUParticle : TF2RocketTrailParticle)
{
  colors[0]  = "1 1 0 0.4";
  colors[1]  = "0 0.4 1 0.5";
  colors[2]  = "0.2 0.4 1 0.3";
  colors[3]  = "0 0 0 0";
};

datablock ParticleEmitterData(TF2RocketTrailCritBLUEmitter : TF2RocketTrailEmitter)
{
  particles = TF2RocketTrailCritBLUParticle;
};

datablock ParticleData(TF2RocketExplosionParticle)
{
  dragCoefficient  = 3.5;
  windCoefficient  = 3.5;
  gravityCoefficient  = -1;
  inheritedVelFactor  = 0.0;
  constantAcceleration  = 0.0;
  //lifetimeMS  = 800;
  //lifetimeMS = 1100;
  lifetimeMS = 800;
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

  //sizes[0]  = 4.0;
  //sizes[1]  = 6.3;
  //sizes[2] = 6.5;
  //sizes[3] = 4.5;
  sizes[0] = 2.25;
  sizes[1] = 4.3;
  sizes[2] = 4.5;
  sizes[3] = 2.75;

  times[0]  = 0.0;
  times[1]  = 0.1;
  times[2] = 0.8;
  times[3] = 1.0;
};

datablock ParticleEmitterData(TF2RocketExplosionEmitter)
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
  particles = TF2RocketExplosionParticle;
};


datablock ParticleData(TF2RocketExplosionPointParticle)
{
  //dragCoefficient   = 6;
  dragCoefficient = 1;
  gravityCoefficient  = 0.5;
  inheritedVelFactor  = 0.2;
  constantAcceleration = 0.0;
  //lifetimeMS        = 1000;
  lifetimeMS = 350;
  textureName       = "base/data/particles/dot";
  spinSpeed  = 10.0;
  spinRandomMin  = -500.0;
  spinRandomMax  = 500.0;
  colors[0]  = "1 1 0 1";
  colors[1]  = "1 1 0 0";
  //sizes[0]   = 8;
  //sizes[1]   = 13;
  sizes[0] = 0.2;
  sizes[1] = 0.2;

  useInvAlpha = false;
};

datablock ParticleEmitterData(TF2RocketExplosionPointEmitter)
{
  lifeTimeMS = 100;

  //ejectionPeriodMS = 1;
  ejectionPeriodMS = 5;
  periodVarianceMS = 0;
  //ejectionVelocity = 60;
  //ejectionVelocity = 20;
  ejectionVelocity = 30;
  velocityVariance = 0.0;
  ejectionOffset  = 0;
  thetaMin      = 0;
  thetaMax      = 180;
  phiReferenceVel  = 0;
  phiVariance   = 360;
  overrideAdvance = false;
  particles = TF2RocketExplosionPointParticle;
};

datablock ParticleData(TF2RocketExplosionChunkParticle)
{
  //dragCoefficient   = 6;
  dragCoefficient = 2;
  gravityCoefficient  = 1;
  inheritedVelFactor  = 0.05;
  constantAcceleration = 0.0;
  lifetimeMS        = 2000;
  lifetimeVarianceMS  = 500;
  textureName       = "base/data/particles/chunk";
  spinSpeed  = 10.0;
  spinRandomMin  = -500.0;
  spinRandomMax  = 500.0;
  colors[0]  = "0.545 0.27 0.07 1";
  colors[1]  = "0.545 0.27 0.07 0";
  //sizes[0]   = 8;
  //sizes[1]   = 13;
  sizes[0] = 0.4;
  sizes[1] = 0.4;

  useInvAlpha = false;
};

datablock ParticleEmitterData(TF2RocketExplosionChunkEmitter)
{
  lifeTimeMS = 100;

  ejectionPeriodMS = 20;
  periodVarianceMS = 0;
  ejectionVelocity = 20;
  velocityVariance = 0.0;
  ejectionOffset  = 0;
  thetaMin      = 0;
  thetaMax      = 45;
  phiReferenceVel  = 0;
  phiVariance   = 360;
  overrideAdvance = false;
  particles = TF2RocketExplosionChunkParticle;
};

datablock ParticleData(TF2RocketExplosionSmokeParticle)
{
  //dragCoefficient   = 6;
  dragCoefficient = 2;
  gravityCoefficient  = -0.25;
  inheritedVelFactor  = 0.05;
  constantAcceleration = 0.0;
  //lifetimeMS        = 2500;
  lifetimeMS = 1250;
  lifetimeVarianceMS  = 250;
  textureName       = "base/data/particles/cloud";

  spinSpeed  = 10;
  spinRandomMin  = -50;
  spinRandomMax  = 50;

  colors[0] = "0.5 0.5 0.5 0";
  colors[1] = "0.7 0.7 0.7 0.06";
  colors[2] = "0.5 0.5 0.5 0";

  //sizes[0] = 7;
  //sizes[1] = 8;
  //sizes[2] = 9;
  sizes[0] = 4;
  sizes[1] = 6;
  sizes[2] = 8;

  times[0] = 0;
  times[1] = 0.25;
  times[2] = 1;

  useInvAlpha = true;
};

datablock ParticleEmitterData(TF2RocketExplosionSmokeEmitter)
{
  lifeTimeMS = 100;

  ejectionPeriodMS = 2;
  periodVarianceMS = 0;
  ejectionVelocity = 5;
  velocityVariance = 0.0;
  ejectionOffset  = 0;
  thetaMin      = 0;
  thetaMax      = 180;
  phiReferenceVel  = 0;
  phiVariance   = 360;
  overrideAdvance = false;
  particles = TF2RocketExplosionSmokeParticle;
};

datablock ExplosionData(TF2RocketLauncherExplosion)
{
  //lifeTimeMS = 500;
  //lifeTimeMS = 150;

  emitter[0] = TF2RocketExplosionEmitter;
  emitter[1] = TF2RocketExplosionPointEmitter;
  emitter[2] = TF2RocketExplosionChunkEmitter;
  emitter[3] = TF2RocketExplosionSmokeEmitter;

  faceViewer  = true;
  explosionScale = "1 1 1";

  shakeCamera = true;
  camShakeFreq = "10.0 11.0 10.0";
  camShakeAmp = "3.0 10.0 3.0";
  camShakeDuration = 0.5;
  camShakeRadius = 20.0;

  // Dynamic light
  lightStartRadius = 10;
  lightEndRadius = 25;
  lightStartColor = "1 1 1 1";
  lightEndColor = "0 0 0 1";

  damageRadius = 169 * $HU_TO_TU;
  radiusDamage = 90;

  impulseRadius = 169 * $HU_TO_TU;
  impulseForce = 3000;
};

addDamageType("TF2RocketLauncher", '<bitmap:Add-Ons/Weapon_Package_TF2/images/CI_Rocket_Launcher> %1', '%2 <bitmap:Add-Ons/Weapon_Package_TF2/images/CI_Rocket_Launcher> %1', 1, 1);
$TF2Damage::IsValid[$DamageType::TF2RocketLauncher] = 1;

datablock ProjectileData(TF2RocketLauncherProjectile)
{
  isTF2Projectile = 1;
  projectileShapeName = "Add-Ons/Weapon_Rocket_Launcher/RocketProjectile.dts";
  directDamage     = 90;
  directDamageType = $DamageType::TF2RocketLauncher;
  radiusDamageType = $DamageType::TF2RocketLauncher;
  impactImpulse  = 800;
  verticalImpulse  = 950;
  explosion        = TF2RocketLauncherExplosion;
  particleEmitter  = TF2RocketTrailEmitter;

  muzzleVelocity = 1100 * $HU_TO_TU;
  velInheritFactor = 0.1;

  armingDelay = 0;
  lifeTime = 4000;
  fadeDelay = 3500;

  hasLight = true;
  lightRadius = 5.0;
  lightColor  = "1 0.5 0.0";
};

datablock ProjectileData(TF2RocketLauncherCritREDProjectile : TF2RocketLauncherProjectile)
{
  particleEmitter = TF2RocketTrailCritREDEmitter;
};

datablock ProjectileData(TF2RocketLauncherCritBLUProjectile : TF2RocketLauncherProjectile)
{
  particleEmitter = TF2RocketTrailCritBLUEmitter;
};

datablock ItemData(TF2RocketLauncherItem)
{
  className = "Weapon";

  shapeFile = "Add-Ons/Weapon_Package_TF2/shapes/RocketLauncher.dts";
  emap = 1;
  mass = 1;
  density = 0.2;
  elasticity = 0.2;
  friction = 0.6;

  uiName = "Rocket Launcher";

  doColorShift = 0;
  colorShiftColor = 184 / 255 SPC 56 / 255 SPC 59 / 255 SPC 1;

  image = TF2RocketLauncherREDImage;
  canDrop = 1;
};

datablock ShapeBaseImageData(TF2RocketLauncherREDImage)
{
  className = "WeaponImage";
  useTF2Projectile = 1;

  shapeFile = "Add-Ons/Weapon_Package_TF2/shapes/RocketLauncher.dts";
  emap = 1;

  mountPoint = 0;
  correctMuzzleVector = 1;

  item = TF2RocketLauncherItem;

  projectile = TF2RocketLauncherProjectile;
  projectileCrit = TF2RocketLauncherCritREDProjectile;
  projectileType = Projectile;

  melee = 0;
  armReady = 1;
  minShotTime = 800;

  //doColorShift = TF2RocketLauncherItem.doColorShift;
  doColorShift = 0;
  colorShiftColor = TF2RocketLauncherItem.colorShiftColor;

  stateName[0]                  = "Activate";
  stateTimeoutValue[0]          = 0.25;
  stateTransitionOnTimeout[0]    = "Ready";
  stateSound[0] = TF2DrawPrimarySound;

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
  stateEmitter[3]      = TF2RocketLauncherSmokeEmitter;
  stateEmitterTime[3]    = 0.05;
  stateEmitterNode[3]    = "muzzleNode";
  stateTimeoutValue[3]         = 0.1;
  stateSequence[3]             = "TrigDown";
  stateTransitionOnTimeout[3]  = "CoolDown";

  stateName[5] = "CoolDown";
  stateTimeoutValue[5]         = 0.7;
  stateTransitionOnTimeout[5]  = "Reload";
  stateSequence[5]             = "TrigDown";

  stateName[4]   = "Reload";
  stateTransitionOnTriggerUp[4]  = "Ready";
  stateSequence[4]  = "TrigDown";

  stateName[6]  = "NoAmmo";
  stateTransitionOnAmmo[6] = "Ready";
};

datablock ShapeBaseImageData(TF2RocketLauncherBLUImage : TF2RocketLauncherREDImage)
{
  projectileCrit = TF2RocketLauncherCritBLUProjectile;
  doColorShift = 0;
  colorShiftColor = "0.345 0.521 0.635 1";
};

function TF2RocketLauncherREDImage::onFire(%this, %obj, %slot)
{
  %p = Parent::onFire(%this, %obj, %slot);

  if (%p.crit == 2)
    %sound = TF2RocketLauncherShootCritSound;
  else
    %sound = TF2RocketLauncherShootSound;

  serverPlay3D(%sound, %obj.getMuzzlePoint(%slot));
  //%obj.playThread(0, "shiftUp");
  %obj.schedule(64, playThread, 0, "shiftUp");

  return %p;
}

function TF2RocketLauncherBLUImage::onFire(%this, %obj, %slot)
{
  return TF2RocketLauncherREDImage::onFire(%this, %obj, %slot);
}

function TF2RocketLauncherProjectile::onExplode(%this, %obj, %a, %b, %c, %d)
{
  %sound = nameToID("TF2Explode" @ getRandom(1, 3) @ "Sound");

  if (isObject(%sound))
  serverPlay3D(%sound, %obj.getPosition());

  Parent::onExplode(%this, %obj, %a, %b, %c, %d);
}

function TF2RocketLauncherCritREDProjectile::onExplode(%this, %obj, %a, %b, %c, %d)
{
  TF2RocketLauncherProjectile::onExplode(%this, %obj, %a, %b, %c, %d);
}

function TF2RocketLauncherCritBLUProjectile::onExplode(%this, %obj, %a, %b, %c, %d)
{
  TF2RocketLauncherProjectile::onExplode(%this, %obj, %a, %b, %c, %d);
}
