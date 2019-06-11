
# GENERAL
- [ ] Look at docs in "TODO" directory
    - [ ] HEAD_TRACKING.txt
        => Infos related to head tracking (as orientation using gyroscope is not reliable)
    - [ ] links.txt
        => Links... (check all and see what to keep)
- [ ] Find how to manage clients connections
    => Server discovery? Hardcoded IP? ...?
- [ ] Clean code
    - [ ] Remove logs ("print", etc.)



# DOCS
- [ ] KINECT_AR.pptx
    - [ ] Update if required
	- [ ] Remove links at end, and move them to "links" file
    - [ ] Could be merged with "KINECT_TRACKING.pptx" (?)
- [ ] KINECT_TRACKING.pptx
    - [ ] Update once implementation choices have been made
    - [ ] Check validity of everything (after tests and evolution)
    - [ ] Replace images taken from Internet where possible
        => To avoid copyright issues (or mention owners when required).
    - [ ] Delete images when done with PPT (?)


# APPS
- [ ] Main
    - [ ] Send less messages to SpaceBrew
        => At time intervals instead of every frame (configurable interval?)
- [ ] Client:
    - [ ] Fit scale of scene
        => HOW TO ADJUST/MEASURE?
    - [ ] Add the "Camera Viewer" object to display video feed as background
        => LOOK AT "VideoBackground.shader" IN VUFORIA!
        => Or do the simple way (as in "Client-camera") - BUT uses too much performances?
    - [ ] Make the changes done during demo at RMIT (stereo view)
        - [ ] Display as VR goggles (stereo views)
            https://developers.google.com/vr/develop/unity/get-started-android
            => Only import required elements from Google VR package
    - [ ] Fix the orientation tracking problem ... (look at "HEAD_TRACKING.txt" in "TODO")
    - [ ] Find solution to specify server IP+port
        => Can't input text when VR UI.
    - [ ] Display calibration init stuff
        => Add counter + "marker" in centre
        ! - Only if still need a calibration phase - depends on new orientation tracking implementation!
    - [ ] Force landscape orientation
        => Setting in editor? Or need to modify Manifest?
- [ ] Libraries:
    - [ ] Remove "Camera Viewer" from this repository
        => Make a separate repostitory, and use it as a submodule.
