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

datablock AudioProfile(TF2Explode1Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/explode1.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2Explode2Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/explode2.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2Explode3Sound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/explode3.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2DrawDefaultSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/draw_default.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2DrawPrimarySound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/draw_primary.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2DrawSecondarySound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/draw_secondary.wav";
  description = AudioClose3d;
  preload = 1;
};

datablock AudioProfile(TF2DrawMeleeSound)
{
  fileName = "Add-Ons/Weapon_Package_TF2/sounds/weapons/draw_melee.wav";
  description = AudioClose3d;
  preload = 1;
};

exec("./critical.cs");
exec("./firing.cs");
exec("./damage.cs");
exec("./players.cs");

exec("./weapons/Rocket Launcher.cs");
exec("./weapons/Grenade Launcher.cs");
exec("./weapons/Shotgun.cs");
exec("./weapons/Scattergun.cs");
exec("./weapons/Pistol.cs");
exec("./weapons/Revolver.cs");
