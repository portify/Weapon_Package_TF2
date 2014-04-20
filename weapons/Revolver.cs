datablock AudioProfile(TF2RevolverShootSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/revolver_shoot.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2RevolverShootCritSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/revolver_shoot_crit.wav";
  description = AudioClose3d;
  preload = 1;
};

addDamageType("TF2Revolver", '<bitmap:Add-Ons/Weapon_Package_TF2/images/CI_Revolver> %1', '%2 <bitmap:Add-Ons/Weapon_Package_TF2/images/CI_Revolver> %1', 1, 1);
$TF2Damage::IsValid[$DamageType::TF2Revolver] = 1;

datablock ItemData(TF2RevolverItem)
{
  className = "Weapon";

  shapeFile = "Add-Ons/Weapon_Package_TF2/shapes/Revolver.dts";
  emap = 1;

  mass = 1;
  density = 0.2;
  elasticity = 0.2;
  friction = 0.6;

  uiName = "Revolver";
  canDrop = 1;
  image = TF2RevolverREDImage;
};

datablock ShapeBaseImageData(TF2RevolverREDImage)
{
  className = "WeaponImage";

  shapeFile = "Add-Ons/Weapon_Package_TF2/shapes/Revolver.dts";
  mountPoint = 0;
  emap = 1;

  item = TF2RevolverItem;
  armReady = 1;
  minShotTime = 600;

  stateName[0] = "Activate";
  stateSound[0] = TF2DrawPrimarySound;
  stateTimeoutValue[0] = 0.25;
  stateTransitionOnTimeout[0] = "Ready";

  stateName[1] = "Ready";
  stateAllowImageChange[1] = 1;
  stateTransitionOnTriggerDown[1] = "Fire";

  stateName[2]                 = "Fire";
  stateFire[2]                 = 1;
  stateScript[2]               = "onFire";
  stateTransitionOnTimeout[2]  = "Smoke";
  stateTimeoutValue[2]         = 0.1;
  stateAllowImageChange[2]     = 0;
  stateWaitForTimeout[2]       = 1;

  stateName[3] = "Smoke";
  stateTimeoutValue[3] = 0.24;
  stateTransitionOnTimeout[3]  = "CoolDown";

  stateName[5] = "CoolDown";
  stateTimeoutValue[5] = 0.24;
  stateTransitionOnTimeout[5]  = "Reload";

  stateName[4] = "Reload";
  stateTransitionOnTriggerUp[4]  = "Ready";

  useTF2Raycast = 1;

  raycastMelee = "";
  raycastRange = 512;
  raycastSpread = 1;
  raycastHitExplosion = GunProjectile;

  directDamage = 40;
  directDamageType = $DamageType::TF2Revolver;
};

datablock ShapeBaseImageData(TF2RevolverBLUImage : TF2RevolverREDImage)
{
  attribute = 1;
};

function TF2RevolverREDImage::onFire(%this, %obj, %slot)
{
  %p = Parent::onFire(%this, %obj, %slot);

  if (%p == 2)
    %sound = TF2RevolverShootCritSound;
  else
    %sound = TF2RevolverShootSound;

  serverPlay3D(%sound, %obj.getMuzzlePoint(%slot));
  %obj.playThread(0, "jump");

  return %p;
}

function TF2RevolverBLUImage::onFire(%this, %obj, %slot)
{
  return TF2RevolverREDImage::onFire(%this, %obj, %slot);
}
