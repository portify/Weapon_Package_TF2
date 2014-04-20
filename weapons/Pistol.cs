datablock AudioProfile(TF2PistolShootSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/pistol_shoot.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2PistolShootCritSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/pistol_shoot_crit.wav";
  description = AudioClose3d;
  preload = 1;
};

addDamageType("TF2Pistol", '<bitmap:Add-Ons/Weapon_Package_TF2/images/CI_Pistol> %1', '%2 <bitmap:Add-Ons/Weapon_Package_TF2/images/CI_Pistol> %1', 1, 1);
$TF2Damage::IsValid[$DamageType::TF2Pistol] = 1;

datablock ItemData(TF2PistolItem)
{
  className = "Weapon";

  shapeFile = "Add-Ons/Weapon_Package_TF2/shapes/Pistol.dts";
  emap = 1;

  mass = 1;
  density = 0.2;
  elasticity = 0.2;
  friction = 0.6;

  uiName = "Pistol";
  canDrop = 1;
  image = TF2PistolREDImage;
};

datablock ShapeBaseImageData(TF2PistolREDImage)
{
  className = "WeaponImage";

  shapeFile = "Add-Ons/Weapon_Package_TF2/shapes/Pistol.dts";
  mountPoint = 0;
  emap = 1;

  item = TF2PistolItem;
  armReady = 1;
  minShotTime = 170;

  stateName[0]                  = "Activate";
  stateTimeoutValue[0]          = 0.25;
  stateTransitionOnTimeout[0]    = "Ready";
  stateSound[0] = TF2DrawSecondarySound;

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
  stateTimeoutValue[3]         = 0.035;
  stateSequence[3]             = "TrigDown";
  stateTransitionOnTimeout[3]  = "CoolDown";

  stateName[5] = "CoolDown";
  stateTimeoutValue[5]         = 0.035;
  stateTransitionOnTimeout[5]  = "Reload";
  stateSequence[5]             = "TrigDown";

  stateName[4]   = "Reload";
  stateTransitionOnTriggerUp[4]  = "Ready";
  stateSequence[4]  = "TrigDown";

  stateName[6]  = "NoAmmo";
  stateTransitionOnAmmo[6] = "Ready";

  useTF2Raycast = 1;

  raycastMelee = "";
  raycastRange = 512;
  raycastSpread = 1;
  raycastHitExplosion = GunProjectile;

  directDamage = 15;
  directDamageType = $DamageType::TF2Pistol;
};

datablock ShapeBaseImageData(TF2PistolBLUImage : TF2PistolREDImage)
{
  attribute = 1;
};

function TF2PistolREDImage::onFire(%this, %obj, %slot)
{
  %p = Parent::onFire(%this, %obj, %slot);

  if (%p == 2)
    %sound = TF2PistolShootCritSound;
  else
    %sound = TF2PistolShootSound;

  serverPlay3D(%sound, %obj.getMuzzlePoint(%slot));
  %obj.playThread(0, "jump");

  return %p;
}

function TF2PistolBLUImage::onFire(%this, %obj, %slot)
{
  return TF2PistolREDImage::onFire(%this, %obj, %slot);
}
