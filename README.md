VJ02
====

VJ02 is VJing software made for [Channel #8] [1].

![Demo] [2]

[Live Video at Channel #8 (YouTube)] [9]

[Demo (Vimeo)] [3]

The application package is available on the [Releases] [4] page, or you can build the app
from the source project.

System Requirements
-------------------

* Requirements for running the app *

Mac OS X 10.6 or later, and a MIDI controller capable of sending CC commands.

* Requirements for editing the source project *

Unity 4.6 or later and Unity Pro license.

Controlling the effects
-----------------------

This project uses [Reaktion] [5] for controlling the effects parameter. When running the
project on Unity Editor, you can override and change the parameters from the Reaktion window.

To open the Reaktion window, choose Window > Reaktion.

![Reaktion window] [6]

These parameters are mapped to MIDI CCs.

| Name                 | CC# | On nanoKontrol |
| -------------------- | --- | -------------- |
| Scroll Speed         |   0 | Fader 1        |
| Object: Sphere       |   1 | Fader 2        |
| Camera Angle (yaw)   |   2 | Fader 3        |
| Camera Angle (pitch) |   3 | Fader 4        |
| Option               |   4 | Fader 5        |
| Post Fx: Slicer      |   5 | Fader 6        |
| Post Fx: Sonar       |   6 | Fader 7        |
| Post Fx: Glitch      |   7 | Fader 8        |
| Lighting Change      |  16 | Knob 1         |
| Ambient Lighting     |  17 | Knob 2         |
| Object: Fan          |  18 | Knob 3         |
| Object: Cubes        |  19 | Knob 4         |
| Object: Cone         |  20 | Knob 5         |
| Object: Balloons     |  21 | Knob 6         |
| Particles            |  22 | Knob 7         |
| Debris               |  23 | Knob 8         |
| Post Fx: Edge Fx     |  32 | S Button 1     |
| Slow-mo              |  33 | S Button 2     |
| Whiteout             |  37 | S Button 6     |
| Color Inversion      |  38 | S Button 7     |
| Camera Shake         |  39 | S Button 8     |

Acknowledgements
----------------

HDR images in [Assets/HDRI Envmaps] [7] are made by [Mr. Bluesummers] [8].

Related Projects
----------------

VJ02 is made of many modules which I previously made. See each project pages for
further information.

- https://github.com/keijiro/ColorSuite
- https://github.com/keijiro/Fragments
- https://github.com/keijiro/UnityFxMeshSet
- https://github.com/keijiro/GlitchFx
- https://github.com/keijiro/Kvant
- https://github.com/keijiro/MidiJack
- https://github.com/keijiro/Reaktion
- https://github.com/keijiro/SlicerFx
- https://github.com/keijiro/SonarFx

[1]: https://www.super-deluxe.com/room/3715/
[2]: http://keijiro.github.io/VJ02/demo.gif
[3]: https://vimeo.com/104780871
[4]: https://github.com/keijiro/VJ02/releases
[5]: https://github.com/keijiro/Reaktion
[6]: http://keijiro.github.io/VJ02/reaktion-window.png
[7]: https://github.com/keijiro/VJ02/tree/master/Assets/HDRI%20Envmaps
[8]: http://www.mrbluesummers.com
[9]: https://www.youtube.com/watch?v=jg0v-8Zb-qo
