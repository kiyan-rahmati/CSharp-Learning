#!/usr/bin/env bash
# Builds every lesson to verify that your SDK/TargetFramework setup works.
cd "$(dirname "$0")" || exit 1
fail=0
for d in [0-9][0-9]-*/; do
  d=${d%/}
  if dotnet build "$d" --nologo -v q >/dev/null 2>&1; then echo "OK    $d"; else echo "FAIL  $d"; fail=1; fi
done
exit $fail
