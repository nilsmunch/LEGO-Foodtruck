# LEGO-foodtruck
 A microgame made for Lego hiring flow

Gameplay demo: https://lizardfactory.itch.io/lego-foodcourt

Simple presentation: https://youtu.be/otgkkufxp7M
Code walkthrough: 

# Process
I was given two thin cases and was asked to pick the one I preferred. I saw the Popcorn cart in **Case2_CreativityFocus** and immediately started doing a simple "Overcooked" style game.
I was only able to put around 8-9 hours in total into this, since I was under the weather.

# Optimization
I wanted to add some nice buildings in the background and found a model on Stud.io. It became quickly apparent that I needed to bake the mesh, since the batches count went well over 4000 for each building.
I did a lightweight mesh baking and wiped the invisible knobs to keep it down a bit. I would have loved to do some deeper baking, but simply did not have the time.

# Managed
- Dispenser machines provide tier 1 items.
- Processing machines convert tier 1 items to tier 2 items.
- Customers spawn every 5 seconds, but cap at 5 customers at the same time.

# Missing
- Didn't manage to get some sound effects nor decoration in.
- No minifigs animated (as per pitched project desc.)
- Interactives should be highlighted visually.
- Testing