//$TU_TO_HU = 20;
//$TU_TO_HU = 31;
//$TU_TO_HU = 40;
$TU_TO_HU = 35;
$HU_TO_TU = 1 / $TU_TO_HU;

datablock AudioDescription(AudioQuiet2D : Audio2D)
{
  volume = 0.85;
};

datablock AudioDescription(AudioLoud2D : Audio2D)
{
  volume = 1.5;
};

exec("./damage.cs");
exec("./players.cs");
exec("./weapons/Rocket Launcher.cs");
