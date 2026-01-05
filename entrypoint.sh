#!/bin/sh
set -e

PORT="${PORT:-10000}"
exec dotnet AutoFix.PortalWWW.dll --urls "http://0.0.0.0:${PORT}"
