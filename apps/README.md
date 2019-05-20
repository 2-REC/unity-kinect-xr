# APPS

## LIBRARIES

Modules or packages used by the different applications.<br>


## MAIN

The main application, the server...<br>
...<br>

Can be used as-is for a base, or integrated to another project.<br>


### PROJECT AS-IS

- Clone the repository<br>
<br>
- If required, manually clone/update the submodule<br>
    git submodule update --init --recursive
<br>
- Run "set_links.bat" script as Administrator<br>
    => It will create the symbolic links between the projects and the submodule.<br>
    - The script has to be run from a CMD window (seems like it doesn't work if right-click->"Run As Administrator")<br>
    - If can't have admin rights, copy the directories manually instead of using symbolic links.<br>
        The directories to copy are:<br>
        - SpaceBrew<br>
        - StreamingAssets<br>
        from "apps\Libraries\network\Assets" to "Assets".<br>
<br>
- Open the project in Unity<br>
<br>
- Import the Kinect for Unity package<br>
    - "Assets" -> "Import Package" -> "Custom Package..."<br>
    - Navigate to "apps\Libraries" or to the download location if downloaded the package separately.<br>
    - Select the package:<br>
        "Kinect.2.0.1410.19000.unitypackage" (or different version if downloaded separately)<br>
    - Import everything<br>
        => Full package: both "Plugins" and "Standard Assets"<br>
<br>
- Move imported assets to Kinect folder<br>
  - from "Plugins"<br>
  - from "Standard Assets"<br>
  ! - MAKE SURE TO ONLY MOVE THE ASSETS RELATED TO KINECT! (the ones imported previously)<br>
<br>
- Open "main" scene<br>


### IN OTHER PROJECT

- Open an existing Unity project or create a new project<br>
<br>
- Clone/Download the repository and its submodules<br>
<br>
- Copy assets from the downloaded repository<br>
    - From "apps\Main\Assets":<br>
        - Kinect: If importing the Kinect package manually, no need to copy "Plugins" and "Standard Assets" directories.<br>
        - Scenes: Might not be necessary, depending on use.<br>
        - Scripts<br>
    - From "apps\Libraries\network\Assets"<br>
        - SpaceBrew<br>
        - StreamingAssets<br>
<br>
- Download the Kinect for Unity package<br>
    ! - OPTIONAL STEP: If want to use the latest version of the package - however, it doesn't seem to change anymore, so the provided package should be enough.<br>
    From:<br>
    https://developer.microsoft.com/en-us/windows/kinect<br>
    ! - It is mentionned that it is a package for Unity Pro, but it works with the free Unity version.<br>
<br>
- Import the Kinect for Unity package<br>
    - "Assets" -> "Import Package" -> "Custom Package..."<br>
    - Navigate to "apps\Libraries" or to the download location if the package was downloaded separately.<br>
    - Select the package:<br>
        "Kinect.2.0.1410.19000.unitypackage" (or different version if downloaded separately)<br>
    - Import everything<br>
        => Full package: both "Plugins" and "Standard Assets"<br>
<br>
- Move imported assets to the "Kinect" folder<br>
    - from "Plugins"<br>
    - from "Standard Assets"<br>
    ! - MAKE SURE TO ONLY MOVE THE ASSETS RELATED TO KINECT! (the ones imported previously)<br>
