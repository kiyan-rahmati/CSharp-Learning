#!/usr/bin/env bash
# Usage: ./run.sh 05      -> runs lesson 05
#        ./run.sh         -> lists all lessons
cd "$(dirname "$0")" || exit 1
if [ -z "$1" ]; then
  ls -d [0-9][0-9]-*/ | sed 's#/##'
  exit 0
fi
dir=$(ls -d "$1"-*/ 2>/dev/null | head -n1)
if [ -z "$dir" ]; then echo "Lesson '$1' not found. Run ./run.sh to list lessons."; exit 1; fi
dotnet run --project "$dir"
