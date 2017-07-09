# Student Name: Rise Riyo
# Project 1: Carnival+ 
# Date: July 9, 2017

* Included files/folders:
 * - README.md
 * - Unity Assets folder
 * - Project Settings folder

* Versions:
 * GVR: 1.5
 * Unity: 5.6.1p2

* +Note: I am a self-paced student resuming the VRND Program. I had to stop the program when I was on VR Design so I had already
completed Project 1: First VR App and had turned it in, but it was not being displayed that I had completed Project 1 in my account. So
I did the Carnival Project thinking that I was responsible for doing it; although Martin Witter and Karen Dragos said I didn't need to after
I spoken to them. But I'll submit the Carnival Project and use it as a refresher for me. Thanks. 

# Work Duration: 
* This project took me approximately 15 hours to complete.

# Challenges
* Coin Toss: I understand the intent of this lesson was to get us to explore/test out various values for both Min and Max Toss Power. I tried a gazillion combinations of values. When I found the secret code for the Coin Toss to be "CTMin10Max13", I started to play with those values. But I found
that the direction of the coins was to the right of the Coin Booth. I started to tweak the CarnivalCoinToss.cs file, particularly TossCoin(), thinking
that I could plug in some numbers for the direction of the coin, but that only made my coin either go directly behind the Player or again to the
right of the booth. So after reading the forum, I made my min single digits and kept my max at 13, moved my GRViewer closer to the booth, moved the
Power Slider to the left of the booth, and was able to score pretty consistently with the given variable values:
   * targetVel.normalized: (0.8, 0.6, 0.1)
   * power: between 6.72751 - 7.350133
   * r.velocity: between (5.2, 4.2, 1.0) to (5.6, 4.6, 1.1)
* Sorry, but I was very confused on the term, "Wiring up". I didn't know if the lesson's author meant by working with the script or something completely different. And when looking at the "directions" in the lesson description, I didn't notice what perhaps 'wiring' was referring to other than the Plinko, but again it was vague to me. BTW, was there a way to tweak the scripts so that the coin landed -- for the most part -- on the Coin booth counter? Just curious. 
* The remaining tasks were straightforward.  
* When building my Carnival app, and then zipping up the files for submissoin, etc. I tested out what I was about to submit, but noticed that it wasn't working at all when I unzipped it and then tried to run Carnival in the Game Engine. I thought maybe it had to do with the StarterScene so I avoided using the script and connecting it to the Main Carnival scene. I've tested it numerous times and once I zip/unzip it, the unzipped version no longer works in the Game Engine. In the console, I see an warning/error: ""Metal: Editor support disabled for earlier than macOS 10.11.6." But I don't know if this issue has anything
to do wtih my Game Engine not running my Carnival app since it is running fine in my original Carnival app on the same computer; I am running 10.10.5. I did try to deploy this same app onto my Android, and it worked fine on the phone. The unzipped one is just not working in the Game Engine. I'll push my code of the original one up to my github repo: https://github.com/riseriyo/carnival_project1 , if you are still having issues with using the app in the Unity Game Engine. Please advise as to why this is happening. Thanks. 


# Extra Features
- Added fireworks based on the video, "How To: Fireworks in Unity". Credit: Tyler Wissler at https://youtu.be/fySBsYh5GsM as of July 9, 2017.
- Attempted to add in a very simple, and not very pretty, StarterScene. It seems to work in Unity, but when deployed on my Android, the StarterScene does not show up on my phone. I was trying to mimic what Project 3: Puzzler did with the canvas as a starter scene, but I didn't have time to figure that out. I'll look into it later, but any tips on how to make my canvas work, please let me know.
- I would like to add in a Timer, but I'm not sure what you guys mean by that. Do you mean, Player has so many seconds to play all games and then it
resets? Or something like that? 

# Rating of Project 1: Carnival
* Good for me to do because it became a refresher course. I listened to all of the vids as well, and most likely will continue doing reviewing 
things in the new platform since my old completed projects (1 through 3) are built for Unity 5.5.0f3 with GRViewer v1.0. 

# References
* Albreda, Zak. "Change Scenes in Unity 5 C#". https://zakalberda.com/2017/03/13/change-scenes-in-unity-5-c/ as of July 9, 2017.
* Albreda, Zak. "Create at start menu/Change scenes in unity 5!". https://www.youtube.com/watch?v=TEq4P0kDAtE as of July 9, 2017.
* Wissler, Tyler. "How To: Fireworks in Unity". https://youtu.be/fySBsYh5GsM as of July 9, 2017.








