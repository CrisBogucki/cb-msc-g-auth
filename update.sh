#!/usr/bin/env sh
set -eu

PRINT_BANNER() {
  echo '
  
 ██████╗        █████╗ ██╗   ██╗████████╗██╗  ██╗
██╔════╝       ██╔══██╗██║   ██║╚══██╔══╝██║  ██║
██║  ███╗█████╗███████║██║   ██║   ██║   ███████║
██║   ██║╚════╝██╔══██║██║   ██║   ██║   ██╔══██║
╚██████╔╝      ██║  ██║╚██████╔╝   ██║   ██║  ██║
 ╚═════╝       ╚═╝  ╚═╝ ╚═════╝    ╚═╝   ╚═╝  ╚═╝
                                                                                                                                                                                                                                                   
'
}

UPDATE_LIBS() {
  echo "Updating  ....................."
  git submodule foreach git pull origin main
  git submodule foreach git fetch
  git submodule foreach git checkout main
  git submodule foreach git submodule update --remote --init
  echo "Updating  ................ done"
}

GENERATE_MODELS() {
  cd lib/smp-lib
  ./modules.sh
  cd ../..
}

PRINT_BANNER
UPDATE_LIBS
GENERATE_MODELS
