#!/bin/sh
cd src

if [ "$TRAVIS_PULL_REQUEST" = "false" ]; then
	mono ../tools/sonar/SonarQube.Scanner.MSBuild.exe begin /n:creatio-labs /k:Creatio-labs_CQRS /d:sonar.login=${SONAR_TOKEN} /d:sonar.host.url="https://sonarcloud.io" /d:sonar.cs.vstest.reportsPaths="**/TestResults/*.trx"
fi

msbuild /p:Configuration=Release Global.Configuration.Dal.sln
mono ../tools/testrunner/NUnit.ConsoleRunner.3.9.0/tools/nunit3-console.exe Global.Configuration.Dal.Tests/bin/Release/Global.Configuration.Dal.Tests.dll

if [ "$TRAVIS_PULL_REQUEST" = "false" ]; then
	mono ../tools/sonar/SonarQube.Scanner.MSBuild.exe end /d:sonar.login=${SONAR_TOKEN}
fi