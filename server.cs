//$TU_TO_HU = 20;
//$TU_TO_HU = 31;
//$TU_TO_HU = 40;
$TU_TO_HU = 35;
$HU_TO_TU = 1 / $TU_TO_HU;

PlayerNoJet.maxHealth = 200;
PlayerNoJet.maxForwardSpeed = 240 * $HU_TO_TU;
PlayerNoJet.maxBackwardSpeed = 216 * $HU_TO_TU;
PlayerNoJet.maxSideSpeed = PlayerNoJet.maxForwardSpeed;
PlayerNoJet.maxForwardCrouchSpeed = PlayerNoJet.maxForwardSpeed * 0.33;
PlayerNoJet.maxBackwardCrouchSpeed = PlayerNoJet.maxBackwardSpeed * 0.33;
PlayerNoJet.maxSideCrouchSpeed = PlayerNoJet.maxSideSpeed * 0.33;

datablock AudioDescription(AudioQuiet2D : Audio2D)
{
  volume = 0.85;
};

datablock AudioDescription(AudioLoud2D : Audio2D)
{
  volume = 1.5;
};

exec("./damage.cs");
exec("./weapons/Rocket Launcher.cs");
