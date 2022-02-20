# See here for image contents: https://github.com/microsoft/vscode-dev-containers/tree/main/containers/dotnet

# [Choice] .NET Core version: 3.1 / 3.1-focal, 5.0 / 5.0-focal, 6.0 /6.0-bullseye, 6.0-focal, 5.0-bullseye, 3.1-bullseye
ARG VARIANT="6.0-focal"
FROM mcr.microsoft.com/vscode/devcontainers/dotnet:${VARIANT}

# [Choice] Node.js version: none, lts/*, 16, 14, 12, 10
ARG NODE_VERSION="none"
RUN if [ "${NODE_VERSION}" != "none" ]; then su vscode -c "umask 0002 && . /usr/local/share/nvm/nvm.sh && nvm install ${NODE_VERSION} 2>&1"; fi

# Avoid warnings by switching to noninteractive
ENV DEBIAN_FRONTEND=noninteractive

# Exercism version
ENV EXERCISM_CLI_VERSION v3.0.13

# Configure apt and install packages
RUN apt-get update \
    && apt-get -y install --no-install-recommends apt-utils dialog 2>&1 \
    && apt-get -y install git iproute2 procps bash-completion

# Install Python
USER root
RUN apt-get update -y \
    && apt-get install -y python3.9 \
    && apt-get install -y python3.8-venv

# Install Exercism stuff
RUN wget "https://github.com/exercism/cli/releases/download/$EXERCISM_CLI_VERSION/exercism-linux-64bit.tgz" && \
    tar xzf exercism-linux-64bit.tgz && \
    mv exercism /usr/local/bin/

# Install Linux stuff
RUN apt-get update \
    && apt-get install tree -y \
    && apt-get install make -y

# Clean up
RUN apt-get autoremove -y \
    && apt-get clean -y \
    && rm -rf /var/lib/apt/lists/* \
    && rm -rf /tmp/downloads

# Switch back to dialog for any ad-hoc use of apt-get
ENV DEBIAN_FRONTEND=dialog

# Startup
COPY docker-entrypoint.sh /usr/local/bin/docker-entrypoint.sh
RUN chmod +x /usr/local/bin/docker-entrypoint.sh
ENTRYPOINT ["/usr/local/bin/docker-entrypoint.sh"]
CMD [ "sleep", "infinity" ]