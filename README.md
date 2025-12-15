EOTech Fix

================

This mod's aim is to fix the long running bug with EOTech sight inaccuracy. People have complained about issues with sight accuracy in Tarkov for a long time. This mod adjusts a value in the material
which appears to be the cause of this inaccuracy. Basically, back before I was working on the VR mod, I noticed an issue I brought up to the original developer about the EOTech sight being totally inaccurate
unless you were looking directly down the middle of the sight. We found that this was caused by the "MarkScale" value when it's set to anything other than 1. This mod effectively adjusts MarkScale to always be 1
and adjusts another value "MarkShift" to adjust the crosshair to be in the correct spot.
