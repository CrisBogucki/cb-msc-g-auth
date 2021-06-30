# cb-msc-g-auth
Globaly User Authentication Microservice in .net core



### Download and setup

Download and setup complete script
```bash
  git clone --recurse-submodules https://github.com/CrisBogucki/cb-msc-g-auth.git
  \cd g-auth
  \git submodule update --remote
  \cd lib/smp-lib/
  \sudo chmod 777 ./generate.sh
  \./generate.sh -m g-auth -t cs
```

Update and generate models
```
  git submodule update --remote
  \cd lib/smp-lib/
  \./generate.sh -m g-auth -t cs
```

### Git
Add submodules
```bash
  git submodule add https://github.com/CrisBogucki/cb-msc-smp-lib.git lib/smp-lib
  \git submodule add https://github.com/CrisBogucki/cb-msc-bcr-lib.git lib/bcr-lib
```

Update submodules from remote

```bash
  git submodule update --remote
```
