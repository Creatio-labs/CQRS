#!/bin/sh

if [ "$TRAVIS_PULL_REQUEST" = "false" ]; then	
	# Install the MSBuild Sonar scanner
	wget -O sonar.zip https://github.com/SonarSource/sonar-scanner-msbuild/releases/download/4.8.0.12008/sonar-scanner-msbuild-4.8.0.12008-net46.zip
	unzip -qq sonar.zip -d tools/sonar
	ls -l tools/sonar
	chmod +x tools/sonar/sonar-scanner-4.2.0.1873/bin/sonar-scanner
fi