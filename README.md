# cb-msc-g-auth
Globaly User Authentication Microservice in .net core

### Download and setup

Download and setup complete script
```bash
  git clone --recurse-submodules https://github.com/CrisBogucki/cb-msc-g-auth.git
  \cd cb-msc-g-auth
  \./update.sh
```

Update and generate models
```bash
  ./update.sh
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

Remove submodules from remote

```bash
  git rm --cached lib/smp-lib
  \git rm --cached lib/bcr-lib
```

Update lib from remote

```bash
git pull origin main
```
