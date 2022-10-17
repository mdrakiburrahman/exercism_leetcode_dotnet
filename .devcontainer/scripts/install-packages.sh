#!/usr/bin/env -S bash -e

export DEBIAN_FRONTEND=noninteractive

apt-get update \
    && apt-get -y install --no-install-recommends apt-utils dialog 2>&1 \
    && apt-get -y install git iproute2 procps bash-completion \
    && apt-get install tree -y \
    && apt-get install make -y

echo "Installing exercism..."
export EXERCISM_CLI_VERSION=v3.0.13
wget "https://github.com/exercism/cli/releases/download/$EXERCISM_CLI_VERSION/exercism-linux-64bit.tgz" && \
    tar xzf exercism-linux-64bit.tgz && \
    mv exercism /usr/local/bin/

echo "Installing yq..."
VERSION=v4.25.1
BINARY=yq_linux_386
sudo wget https://github.com/mikefarah/yq/releases/download/${VERSION}/${BINARY} -O /usr/bin/yq \
    && sudo chmod +x /usr/bin/yq

apt-get autoremove -y \
&& apt-get clean -y \
&& rm -rf /var/lib/apt/lists/* \
&& rm -rf /tmp/downloads