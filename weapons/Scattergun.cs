datablock AudioProfile(TF2ScattergunShootSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/scatter_gun_shoot.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2ScattergunShootCritSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/scatter_gun_shoot_crit.wav";
  description = AudioClose3d;
  preload = 1;
};

addDamageType("TF2Scattergun", '<bitmap:Add-Ons/Weapon_Package_TF2/images/CI_Scattergun> %1', '%2 <bitmap:Add-Ons/Weapon_Package_TF2/images/CI_Scattergun> %1', 1, 1);
$TF2Damage::IsValid[$DamageType::TF2Scattergun] = 1;

datablock ItemData(TF2ScattergunItem)
{
  className = "Weapon";

  shapeFile = "Add-Ons/Weapon_Package_TF2/shapes/Scattergun.dts";
  emap = 1;

  mass = 1;
  density = 0.2;
  elasticity = 0.2;
  friction = 0.6;

  uiName = "Scattergun";
  canDrop = 1;
  image = TF2ScattergunREDImage;
};

datablock ShapeBaseImageData(TF2ScattergunREDImage)
{
  className = "WeaponImage";

  shapeFile = "Add-Ons/Weapon_Package_TF2/shapes/Scattergun.dts";
  mountPoint = 0;
  emap = 1;

  item = TF2ScattergunItem;
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
  directDamageType = $DamageType::TF2Scattergun;
};

datablock ShapeBaseImageData(TF2ScattergunBLUImage : TF2ScattergunREDImage)
{
  attribute = 1;
};

function TF2ScattergunREDImage::onFire(%this, %obj, %slot)
{
  %p = Parent::onFire(%this, %obj, %slot);

  if (%p == 2)
    %sound = TF2ScattergunShootCritSound;
  else
    %sound = TF2ScattergunShootSound;

  serverPlay3D(%sound, %obj.getMuzzlePoint(%slot));
  %obj.playThread(0, "jump");
  %obj.schedule(50, playThread, 2, "rotCW");
  //%obj.schedule(10, playThread, 2, "rotCCW");

  return %p;
}

function TF2ScattergunBLUImage::onFire(%this, %obj, %slot)
{
  return TF2ScattergunREDImage::onFire(%this, %obj, %slot);
}
