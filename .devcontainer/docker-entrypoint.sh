#!/bin/bash

echo "Configuring wakatime..."
printf "\n[settings]\napi_key = $WAKA_TIME_API_KEY\n" > ~/.wakatime.cfg;

echo "Configuring exercism..."
exercism configure --token=$EXERCISM_TOKEN -w /workspace;
mkdir -p /workspace/$TRACK;
cd /workspace/$TRACK;

exec "$@"