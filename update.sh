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
  for lib in bcr-lib smp-lib 
  do
    UPDATE_LIB $lib
  done
}

GENERATE_MODELS() {
  cd lib/smp-lib
  ./modules.sh
  cd ../..
}

UPDATE_LIB() {
  cd lib/$1
  echo "Updating $1 ....................."
  git submodule update --remote --init
  git submodule foreach git pull
  echo "Updating $1 ................ done"
  cd ../..
}

PRINT_BANNER
UPDATE_LIBS
GENERATE_MODELS
