FROM ubuntu:16.04

RUN apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF \
&& echo "deb http://download.mono-project.com/repo/ubuntu xenial main" | tee /etc/apt/sources.list.d/mono-official.list

RUN apt-get update \
  && apt-get install -y make \
  && apt-get install -y mono-devel

VOLUME /app

WORKDIR /app

CMD make run