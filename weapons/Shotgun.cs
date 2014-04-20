datablock AudioProfile(TF2ShotgunShootSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/shotgun_shoot.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2ShotgunShootCritSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/shotgun_shoot_crit.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2ShotgunCockBackSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/shotgun_cock_back.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2ShotgunCockForwardSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/shotgun_cock_forward.wav";
  description = AudioClose3d;
  preload = 1;
};

addDamageType("TF2Shotgun", '<bitmap:Add-Ons/Weapon_Package_TF2/images/CI_Shotgun> %1', '%2 <bitmap:Add-Ons/Weapon_Package_TF2/images/CI_Shotgun> %1', 1, 1);
//addDamageType("TF2Shotgun", '<bitmap:base/client/ui/ci/generic> %1', '%2 <bitmap:base/client/ui/ci/generic> %1', 1, 1);
$TF2Damage::IsValid[$DamageType::TF2Shotgun] = 1;

datablock ItemData(TF2ShotgunItem)
{
  className = "Weapon";

  shapeFile = "Add-Ons/Weapon_Package_TF2/shapes/Shotgun.dts";
  emap = 1;

  mass = 1;
  density = 0.2;
  elasticity = 0.2;
  friction = 0.6;

  uiName = "Shotgun";
  canDrop = 1;
  image = TF2ShotgunREDImage;
};

datablock ShapeBaseImageData(TF2ShotgunREDImage)
{
  className = "WeaponImage";

  shapeFile = "Add-Ons/Weapon_Package_TF2/shapes/Shotgun.dts";
  mountPoint = 0;
  emap = 1;

  item = TF2ShotgunItem;
  armReady = 1;
  minShotTime = 600;

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
  stateTimeoutValue[3]         = 0.1;
  stateSequence[3]             = "TrigDown";
  stateTransitionOnTimeout[3]  = "CoolDown";

  stateName[5] = "CoolDown";
  stateTimeoutValue[5]         = 0.4;
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
  raycastCount = 10;
  raycastSpread = 3.81 * 2;
  raycastSpreadExempt = 1;
  raycastHitExplosion = GunProjectile;

  directDamage = 6;
  directDamageType = $DamageType::TF2Shotgun;
};

datablock ShapeBaseImageData(TF2ShotgunBLUImage : TF2ShotgunREDImage)
{
  attribute = 1;
};

function TF2ShotgunREDImage::onFire(%this, %obj, %slot)
{
  %p = Parent::onFire(%this, %obj, %slot);

  if (%p == 2)
    %sound = TF2ShotgunShootCritSound;
  else
    %sound = TF2ShotgunShootSound;

  serverPlay3D(%sound, %obj.getMuzzlePoint(%slot));

  schedule(250, 0, serverPlay3D, TF2ShotgunCockForwardSound, %obj.getMuzzlePoint(%slot));
  schedule(400, 0, serverPlay3D, TF2ShotgunCockBackSound, %obj.getMuzzlePoint(%slot));
  //schedule(450, 0, serverPlay3D, TF2ShotgunCockBackSound, %obj.getMuzzlePoint(%slot));
  %obj.playThread(0, "jump");

  return %p;
}

function TF2ShotgunBLUImage::onFire(%this, %obj, %slot)
{
  return TF2ShotgunREDImage::onFire(%this, %obj, %slot);
}
