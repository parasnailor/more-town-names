#!/bin/bash

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
MOD_NAME="TownNamesMod"
BUILD_CONFIG="Release"
TARGET_FRAMEWORK="net472"
DIST_DIR="$SCRIPT_DIR/dist"
MOD_DIR="$DIST_DIR/$MOD_NAME"

echo "=== Against the Storm Town Names Mod - Packaging Script ==="
echo ""

# Step 1: Build the project
echo "[1/5] Building mod..."
dotnet clean "$SCRIPT_DIR/TownNamesMod.csproj" -c $BUILD_CONFIG -q 2>/dev/null || true
dotnet build "$SCRIPT_DIR/TownNamesMod.csproj" -c $BUILD_CONFIG
echo "✓ Build complete"
echo ""

# Step 2: Clean and create distribution directories
echo "[2/5] Creating distribution structure..."
rm -rf "$DIST_DIR"
mkdir -p "$MOD_DIR/plugins"
mkdir -p "$MOD_DIR/config"
echo "✓ Directories created"
echo ""

# Step 3: Copy compiled DLL
echo "[3/5] Copying compiled DLL..."
DLL_PATH="$SCRIPT_DIR/bin/$BUILD_CONFIG/$TARGET_FRAMEWORK/TownNamesMod.dll"
if [ ! -f "$DLL_PATH" ]; then
    echo "✗ Error: DLL not found at $DLL_PATH"
    exit 1
fi
cp "$DLL_PATH" "$MOD_DIR/plugins/"
echo "✓ DLL copied"
echo ""

# Step 4: Copy configuration and documentation
echo "[4/5] Copying config files..."
cp "$SCRIPT_DIR/Config/townnames.txt" "$MOD_DIR/config/"
cp "$SCRIPT_DIR/manifest.json" "$MOD_DIR/"
cp "$SCRIPT_DIR/README.md" "$MOD_DIR/"
echo "✓ Config files copied"
echo ""

# Step 5: Create zip archive
echo "[5/5] Creating distribution archive..."
cd "$DIST_DIR"
zip -r -q "${MOD_NAME}.zip" "$MOD_NAME/"
cd "$SCRIPT_DIR"
echo "✓ Archive created"
echo ""

echo "=== Packaging Complete ==="
echo ""
echo "Distribution files:"
echo "  Directory: $MOD_DIR"
echo "  Archive:   $DIST_DIR/${MOD_NAME}.zip"
echo ""
echo "Ready to upload to Thunderstore!"
