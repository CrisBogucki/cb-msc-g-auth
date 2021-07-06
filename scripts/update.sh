cd ..
# update submodules
git submodule update --remote
# build models for modules dependency
cd lib/smp-lib
./modules.sh