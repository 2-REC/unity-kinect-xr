echo off

cd Main
cd Assets

rem del StreamingAssets
md StreamingAssets
cd StreamingAssets
rem mklink /D StreamingAssets "..\..\Libraries\network\Assets\StreamingAssets
rem rmdir /Q /S .node
rem del /F .node
mklink /D .node "..\..\..\Libraries\network\Assets\StreamingAssets\.node
rem rmdir /Q /S .spacebrew
rem del /F .spacebrew
mklink /D .spacebrew "..\..\..\Libraries\network\Assets\StreamingAssets\.spacebrew
cd..

md SpaceBrew
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
