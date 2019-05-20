echo off

cd Main
cd Assets

md StreamingAssets
cd StreamingAssets
mklink /D .node "..\..\..\Libraries\network\Assets\StreamingAssets\.node
mklink /D .spacebrew "..\..\..\Libraries\network\Assets\StreamingAssets\.spacebrew
cd..

md SpaceBrew
cd SpaceBrew
mklink /D Editor "..\..\..\Libraries\network\Assets\SpaceBrew\Editor
mklink /D NodeJs "..\..\..\Libraries\network\Assets\SpaceBrew\NodeJs
mklink /D Plugins "..\..\..\Libraries\network\Assets\SpaceBrew\Plugins
mklink /D Prefabs "..\..\..\Libraries\network\Assets\SpaceBrew\Prefabs
mklink /D Scripts "..\..\..\Libraries\network\Assets\SpaceBrew\Scripts
cd ../../..
