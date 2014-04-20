$SPEED_SCOUT    = 400 * $HU_TO_TU;
$SPEED_SOLDIER  = 240 * $HU_TO_TU;
$SPEED_PYRO     = 300 * $HU_TO_TU;
$SPEED_DEMOMAN  = 280 * $HU_TO_TU;
$SPEED_HEAVY    = 230 * $HU_TO_TU;
$SPEED_ENGINEER = 300 * $HU_TO_TU;
$SPEED_MEDIC    = 320 * $HU_TO_TU;
$SPEED_SNIPER   = 300 * $HU_TO_TU;
$SPEED_SPY      = 300 * $HU_TO_TU;

datablock PlayerData(PlayerTF2Scout : PlayerStandardArmor)
{
  uiName = "TF2 - Scout";
  //jumpForce = -2 * 45 * -800 * $HU_TO_TU * 90;
  jumpForce = 860;
  airControl = 0.25;

  canJet = 0;
  firstPersonOnly = 1;

  maxDamage = 125;
  jumpForce = 720;  maxTools = 3;

  maxForwardSpeed = $SPEED_SCOUT;
  maxBackwardSpeed = $SPEED_SCOUT * 0.9;
  maxSideSpeed = $SPEED_SCOUT;

  maxForwardCrouchSpeed = $SPEED_SCOUT * 0.33;
  maxBackwardCrouchSpeed = $SPEED_SCOUT * 0.9 * 0.33;
  maxSideCrouchSpeed = $SPEED_SCOUT * 0.33;
};

datablock PlayerData(PlayerTF2ScoutJumped : PlayerTF2Scout)
{
  uiName = "";
  airControl = 1;
};

datablock PlayerData(PlayerTF2Soldier : PlayerTF2Scout)
{
  uiName = "TF2 - Soldier";
  maxDamage = 200;
  jumpForce = 720;
  maxForwardSpeed = $SPEED_SOLDIER;
  maxBackwardSpeed = $SPEED_SOLDIER * 0.9;
  maxSideSpeed = $SPEED_SOLDIER;

  maxForwardCrouchSpeed = $SPEED_SOLDIER * 0.33;
  maxBackwardCrouchSpeed = $SPEED_SOLDIER * 0.9 * 0.33;
  maxSideCrouchSpeed = $SPEED_SOLDIER * 0.33;
};

datablock PlayerData(PlayerTF2Pyro : PlayerTF2Scout)
{
  uiName = "TF2 - Pyro";
  maxDamage = 175;
  jumpForce = 720;
  maxForwardSpeed = $SPEED_PYRO;
  maxBackwardSpeed = $SPEED_PYRO * 0.9;
  maxSideSpeed = $SPEED_PYRO;

  maxForwardCrouchSpeed = $SPEED_PYRO * 0.33;
  maxBackwardCrouchSpeed = $SPEED_PYRO * 0.9 * 0.33;
  maxSideCrouchSpeed = $SPEED_PYRO * 0.33;
};

datablock PlayerData(PlayerTF2Demoman : PlayerTF2Scout)
{
  uiName = "TF2 - Demoman";
  maxDamage = 175;
  jumpForce = 720;
  maxForwardSpeed = $SPEED_DEMOMAN;
  maxBackwardSpeed = $SPEED_DEMOMAN * 0.9;
  maxSideSpeed = $SPEED_DEMOMAN;

  maxForwardCrouchSpeed = $SPEED_DEMOMAN * 0.33;
  maxBackwardCrouchSpeed = $SPEED_DEMOMAN * 0.9 * 0.33;
  maxSideCrouchSpeed = $SPEED_DEMOMAN * 0.33;
};

datablock PlayerData(PlayerTF2Heavy : PlayerTF2Scout)
{
  uiName = "TF2 - Heavy";
  maxDamage = 300;
  jumpForce = 720;
  maxForwardSpeed = $SPEED_HEAVY;
  maxBackwardSpeed = $SPEED_HEAVY * 0.9;
  maxSideSpeed = $SPEED_HEAVY;

  maxForwardCrouchSpeed = $SPEED_HEAVY * 0.33;
  maxBackwardCrouchSpeed = $SPEED_HEAVY * 0.9 * 0.33;
  maxSideCrouchSpeed = $SPEED_HEAVY * 0.33;
};

datablock PlayerData(PlayerTF2Engineer : PlayerTF2Scout)
{
  uiName = "TF2 - Engineer";

  maxDamage = 125;
  jumpForce = 720;  maxTools = 5;

  maxForwardSpeed = $SPEED_ENGINEER;
  maxBackwardSpeed = $SPEED_ENGINEER * 0.9;
  maxSideSpeed = $SPEED_ENGINEER;

  maxForwardCrouchSpeed = $SPEED_ENGINEER * 0.33;
  maxBackwardCrouchSpeed = $SPEED_ENGINEER * 0.9 * 0.33;
  maxSideCrouchSpeed = $SPEED_ENGINEER * 0.33;
};

datablock PlayerData(PlayerTF2Medic : PlayerTF2Scout)
{
  uiName = "TF2 - Medic";
  maxDamage = 150;
  jumpForce = 720;
  maxForwardSpeed = $SPEED_MEDIC;
  maxBackwardSpeed = $SPEED_MEDIC * 0.9;
  maxSideSpeed = $SPEED_MEDIC;

  maxForwardCrouchSpeed = $SPEED_MEDIC * 0.33;
  maxBackwardCrouchSpeed = $SPEED_MEDIC * 0.9 * 0.33;
  maxSideCrouchSpeed = $SPEED_MEDIC * 0.33;
};

datablock PlayerData(PlayerTF2Sniper : PlayerTF2Scout)
{
  uiName = "TF2 - Sniper";
  maxDamage = 125;
  jumpForce = 720;
  maxForwardSpeed = $SPEED_SNIPER;
  maxBackwardSpeed = $SPEED_SNIPER * 0.9;
  maxSideSpeed = $SPEED_SNIPER;

  maxForwardCrouchSpeed = $SPEED_SNIPER * 0.33;
  maxBackwardCrouchSpeed = $SPEED_SNIPER * 0.9 * 0.33;
  maxSideCrouchSpeed = $SPEED_SNIPER * 0.33;
};

datablock PlayerData(PlayerTF2Spy : PlayerTF2Scout)
{
  uiName = "TF2 - Spy";

  maxDamage = 125;
  jumpForce = 720;  maxTools = 4;

  maxForwardSpeed = $SPEED_SPY;
  maxBackwardSpeed = $SPEED_SPY * 0.9;
  maxSideSpeed = $SPEED_SPY;

  maxForwardCrouchSpeed = $SPEED_SPY * 0.33;
  maxBackwardCrouchSpeed = $SPEED_SPY * 0.9 * 0.33;
  maxSideCrouchSpeed = $SPEED_SPY * 0.33;
};

function PlayerTF2Scout::onTrigger(%this, %obj, %slot, %value)
{
  Parent::onTrigger(%this, %obj, %slot, %value);

  if (!%value || %slot != 2)
    return;

  %pos = %obj.getPosition();
  %mask = $TypeMasks::FxBrickAlwaysObjectType | $TypeMasks::PlayerObjectType | $TypeMasks::StaticObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::VehicleObjectType;

  %ray = containerRayCast(%pos, vectorAdd(%pos, "0 0 -0.3"), %mask, %obj);

  if (%ray && (!(%ray.getType() & $TypeMasks::FxBrickAlwaysObjectType) || %ray.isColliding()))
    return;

  %obj.setVelocity("0 0 0");
  %obj.applyImpulse("0 0 0", "0 0" SPC %this.jumpForce);
  %obj.playThread(3, "jump");

  %p = new Projectile()
  {
    dataBlock = pushBroomProjectile;
    initialPosition = %pos;
    initialVelocity = "0 0 -1";
    sourceObject = %obj;
    client = %obj.client;
    sourceSlot = 0;
    originPoint = %pos;
  };

  MissionCleanup.add(%p);
  %p.explode();

  %obj.setDataBlock(PlayerTF2ScoutJumped);
  //%obj.checkDoubleJump = %obj.schedule(16, checkDoubleJump);
}

function PlayerTF2ScoutJumped::onNewDataBlock(%this, %obj)
{
  Parent::onNewDataBlock(%this, %obj);
  %obj.checkDoubleJump = %obj.schedule(75, checkDoubleJump);
}

function Player::checkDoubleJump(%this)
{
  cancel(%this.checkDoubleJump);

  if (%this.getDataBlock() != nameToID("PlayerTF2ScoutJumped"))
    return;

  if (%this.getState() $= "Dead")
  {
    %this.changeDataBlock("PlayerTF2Scout");
    return;
  }

  %pos = %this.getPosition();
  %mask = $TypeMasks::FxBrickAlwaysObjectType | $TypeMasks::PlayerObjectType | $TypeMasks::StaticObjectType | $TypeMasks::TerrainObjectType | $TypeMasks::VehicleObjectType;

  %ray = containerRayCast(%pos, vectorAdd(%pos, "0 0 -0.3"), %mask, %this);

  if (!%ray || !(!(%ray.getType() & $TypeMasks::FxBrickAlwaysObjectType) || %ray.isColliding()))
    %this.checkDoubleJump = %this.schedule(24, checkDoubleJump);
  else
    %this.changeDataBlock(PlayerTF2Scout);
}

function PlayerTF2Medic::onNewDataBlock(%this, %obj)
{
  if (!isEventPending(%obj.regenHealthSchedule))
    %obj.regenHealthSchedule = %obj.schedule(0, regenHealthSchedule);
}

function Player::regenHealthSchedule(%this)
{
  cancel(%this.regenHealthSchedule);

  if (%this.getState() $= "Dead" || %this.getDataBlock() != nameToID("PlayerTF2Medic"))
    return;

  %time = $Sim::Time - %this.lastTF2DamageTime;

  %health = 3 + mClampF(%time / 10, 0, 1) * 3;
  %damage = %this.getDamageLevel();

  if (%damage < %health)
    %this.setDamageLevel(0);
  else
    %this.setDamageLevel(%damage - %health);

  %this.regenHealthSchedule = %this.schedule(1000, regenHealthSchedule);
}
