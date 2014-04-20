datablock ParticleData(TF2CriticalHitParticle)
{
   dragCoefficient      = 5;
   gravityCoefficient   = 0;
   inheritedVelFactor   = 0;
   windCoefficient      = 0;
   constantAcceleration = 0;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 0;
   useInvAlpha          = 0;
   textureName          = "Add-Ons/Weapon_Package_TF2/images/Critical_Hit";

   colors[0] = "0 1 0 1";
   colors[1] = "1 0 0 1";
   colors[2] = "1 0 0 0";

   sizes[0] = 1.5;
   sizes[1] = 1.5;
   sizes[2] = 1.4;

   times[0] = 0;
   times[1] = 0.6;
   times[2] = 1;
};

datablock ParticleEmitterData(TF2CriticalHitEmitter)
{
   ejectionPeriodMS = 35;
   periodVarianceMS = 0;
   ejectionVelocity = 0;
   ejectionOffset = 1.8;
   velocityVariance = 0;

   thetaMin = 0;
   thetaMax = 0;

   phiReferenceVel  = 0;
   phiVariance = 0;

   lifeTimeMS = 100;
   particles = TF2CriticalHitParticle;

   doFalloff = 0;
   overrideAdvance = 0;

   emitterNode = GenericEmitterNode;
   pointEmitterNode = TenthEmitterNode;
};

datablock ExplosionData(TF2CriticalHitExplosion)
{
   lifeTimeMS = 2000;
   emitter[0] = TF2CriticalHitEmitter;
};

datablock ProjectileData(TF2CriticalHitProjectile)
{
   explosion = TF2CriticalHitExplosion;

   lifeTime = 10;
   armingDelay = 0;
   explodeOnDeath = true;
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

datablock AudioProfile(TF2CritPowerSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/crit_power.wav";
  description = AudioCloseLooping3D;
  preload = 1;
};

datablock ParticleData(TF2CritBoostREDParticle)
{
  textureName = "Add-Ons/Weapon_Package_TF2/images/Critical_Spark";

  dragCoefficient = 0;
  gravityCoefficient = 0;
  inheritedVelFactor = 1;
  constantAcceleration = 0;

  lifetimeMS = 125;
  lifetimeVarianceMS = 0;

  spinSpeed = 1;
  spinRandomMin = 90;
  spinRandomMax = 90;

  colors[0] = "1 0.25 0.25 1";
  colors[1] = "1 0.25 0.25 0";

  sizes[0] = 1.5;
  sizes[1] = 0.5;

  times[0] = 0;
  times[1] = 1;
};

datablock particleEmitterData(TF2CritBoostREDEmitter)
{
  particles = TF2CritBoostRedParticle;

  ejectionPeriodMS = 2;
  periodVarianceMS = 0;
  ejectionVelocity = 0;
  velocityVariance = 0;
  ejectionOffset = 0.5;

  thetaMin = -90;
  thetaMax = 90;

  phiReferenceVel = 360;
  phiVariance = 0;

  overrideAdvance = 0;
  useEmitterColors = 1;
};

datablock ExplosionData(TF2CritBoostREDExplosion)
{
  lifeTimeMS = 500;

  particleEmitter = TF2CritBoostREDEmitter;
  particleDensity = 3;
  particleRadius = 0.1;

  faceViewer = 1;
  shakeCamera = 0;
};

datablock ProjectileData(TF2CritBoostREDProjectile)
{
  explosion = TF2CritBoostREDExplosion;
};

datablock ParticleData(TF2CritBoostBLUParticle : TF2CritBoostREDParticle)
{
  colors[0] = "0.25 0.25 1 1";
  colors[1] = "0.25 0.25 1 1";
};

datablock ParticleEmitterData(TF2CritBoostBLUEmitter : TF2CritBoostREDEmitter)
{
  particles = TF2CritBoostBLUParticle;
};

datablock ExplosionData(TF2CritBoostBLUExplosion : TF2CritBoostREDExplosion)
{
  particleEmitter = TF2CritBoostBLUEmitter;
};

datablock projectileData(TF2CritBoostBLUProjectile : TF2CritBoostREDProjectile)
{
  explosion = TF2CritBoostBLUExplosion;
};

function Player::setCritBoost(%this, %value)
{
  %this.hasCrits = %value ? 1 : 0;
  %this.critBoost = %this.hasCrits ? 2 : (%this.hasMiniCrits ? 1 : 0);

  if (%value)
  {
    %this.critBoostEffect = %this.schedule(100, "critBoostEffect");
    %this.playAudio(1, TF2CritPowerSound);
  }
  else
    %this.stopAudio(1);
}

function Player::setMiniCritBoost(%this, %value)
{
  %this.hasMiniCrits = %value ? 1 : 0;
  %this.critBoost = %this.hasCrits ? 2 : (%this.hasMiniCrits ? 1 : 0);
}

function player::critBoostEffect(%this)
{
  cancel(%this.critBoostEffect);

  if (!%this.hasCrits)
    return;

  if (0)
    %db = TF2CritBoostBLUProjectile;
  else
    %db = TF2CritBoostREDProjectile;

  %obj = new Projectile()
  {
    dataBlock = %db;
    initialPosition = %this.getMuzzlePoint(0);
  };

  MissionCleanup.add(%obj);

  %obj.setScale( "0.5 0.5 0.5" );
  %obj.explode();

  %this.critBoostEffect = %this.schedule(100, "critBoostEffect");
}

function Player::rollCritical(%this, %melee)
{
  %chance = %melee ? 0.15 : 0.02;
  %chance += mClampF(%this.recentDamage / 800, 0, 1) * (%melee ? 0.45 : 0.1);

  %crit = getRandom() < %chance ? 2 : 0;
  %crit = mClamp(getMax(%crit, %this.critBoost), 0, 2);

  if (%crit < $GlobalCrits && $GlobalCrits > 0)
    %crit = $GlobalCrits;

  return %crit;
}
