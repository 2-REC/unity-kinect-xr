echo off

cd Main
cd Assets

rem del StreamingAssets
md StreamingAssets
cd StreamingAssets
rem mklink /D StreamingAssets "..\..\Libraries\network\Assets\StreamingAssets
rmdir /Q /S .node
del /F .node
mklink /D .node "..\..\..\Libraries\network\Assets\StreamingAssets\.node
rmdir /Q /S .spacebrew
del /F .spacebrew
mklink /D .spacebrew "..\..\..\Libraries\network\Assets\StreamingAssets\.spacebrew
cd..

cd SpaceBrew

rmdir /Q /S Editor
del /F Editor
mklink /D Editor "..\..\..\Libraries\network\Assets\SpaceBrew\Editor
rmdir /Q /S NodeJs
del /F NodeJs
mklink /D NodeJs "..\..\..\Libraries\network\Assets\SpaceBrew\NodeJs
rmdir /Q /S Plugins
del /F Plugins
mklink /D Plugins "..\..\..\Libraries\network\Assets\SpaceBrew\Plugins
rmdir /Q /S Prefabs
del /F Prefabs
mklink /D Prefabs "..\..\..\Libraries\network\Assets\SpaceBrew\Prefabs
rmdir /Q /S Scripts
del /F Scripts
mklink /D Scripts "..\..\..\Libraries\network\Assets\SpaceBrew\Scripts

cd ../../..
