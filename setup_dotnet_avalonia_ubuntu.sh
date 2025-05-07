#!/bin/bash

# Step 1: Remove any existing .NET installations
echo "Removing existing .NET installations..."
sudo apt remove -y 'dotnet*' 'aspnetcore*' 'netstandard*'
sudo apt autoremove -y
sudo rm -rf /usr/share/dotnet
sudo rm -rf $HOME/.dotnet

# Step 2: Add Microsoft package repository
echo "Adding Microsoft package repository..."
wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

# Step 3: Install .NET SDK 8.0 (LTS)
echo "Updating package lists and installing .NET SDK 8.0..."
sudo apt update
sudo apt install -y dotnet-sdk-8.0

# Step 4: Verify the installation
echo "Verifying .NET SDK installation..."
dotnet --list-sdks

# Step 5: Set up environment variables
echo "Setting up environment variables in ~/.bashrc..."
echo 'export DOTNET_ROOT=/usr/share/dotnet' >> ~/.bashrc
echo 'export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools' >> ~/.bashrc

echo "Reloading ~/.bashrc..."
source ~/.bashrc

# Step 6: Recreate Avalonia project
echo "Creating Avalonia project in ~/Projects/CounselingPlatform..."
mkdir -p ~/Projects
cd ~/Projects

dotnet new avalonia.app -n CounselingPlatform
cd CounselingPlatform

dotnet add package Avalonia.Desktop
dotnet add package Avalonia.ReactiveUI
dotnet add package Microsoft.Data.SqlClient

# Step 7: Try running the project
echo "Running the Avalonia project..."
dotnet run

# Step 8: Troubleshooting instructions (if needed)
echo "If you encounter errors, check your Ubuntu version with:"
echo "  lsb_release -a"
echo "Install dependencies if needed:"
echo "  sudo apt install -y libgdiplus libc6-dev libgtk-3-0 libx11-dev"
echo "Alternative installation method (if apt install fails):"
echo "  wget https://dot.net/v1/dotnet-install.sh"
echo "  chmod +x dotnet-install.sh"
echo "  ./dotnet-install.sh --channel 8.0"
echo "Final verification commands:"
echo "  which dotnet"
echo "  dotnet --info"
