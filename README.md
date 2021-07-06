# cb-msc-g-auth
Globaly User Authentication Microservice in .net core



### Download and setup

Download and setup complete script
```bash
  git clone --recurse-submodules https://github.com/CrisBogucki/cb-msc-g-auth.git
  \cd cb-msc-g-auth
  \git submodule update --remote
  \cd lib/smp-lib
  \./modules.sh
```

Update and generate models
```bash
  cd ./scripts
  \./scripts/update.sh
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
