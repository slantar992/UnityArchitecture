# Version 0.3.2
## Tweaks
* FSM
  * Default constructor replaced by one without parameters.
  * Mandatory Start() method added
# Version 0.3.1
## Tweaks
* FSM
  * Default constructor added
  * ForceState method added
  * Chain state and transition additions is possible
* Log
  * ILogFormatter interface added
  * Date formatter added (TimestampLogFormatter)
# Version 0.3.0
## Features
* Finite state machine implemented
* Event bus added
* Logs implementations added:
  * Unity
  * System console
  * In file
  * Composite (combination of one or more logs implementations)

---
# Version 0.2.0
## Features
* Bootstrapper importer on _Tools/Slantar/Architecture_ on Unity Editor menu items
## Tweaks
* Container class name changed to ServiceLocator
* Arch class name changed to Services

---
# Version 0.1.0
## Features
* Service locator added