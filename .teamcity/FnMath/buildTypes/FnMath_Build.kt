package FnMath.buildTypes

import jetbrains.buildServer.configs.kotlin.v2017_2.*
import jetbrains.buildServer.configs.kotlin.v2017_2.buildSteps.MSBuildStep
import jetbrains.buildServer.configs.kotlin.v2017_2.buildSteps.msBuild
import jetbrains.buildServer.configs.kotlin.v2017_2.triggers.vcs

object FnMath_Build : BuildType({
    uuid = "55f90bff-36ef-4e6a-b38d-0d7649e13b2a"
    id = "FnMath_Build"
    name = "Build"

    vcs {
        root(FnMath.vcsRoots.FnMath_HttpsGithubComSNovakInCommFnMathGitRefsHeadsMaster)

    }

    steps {
        dotnetRestore {
            name = "Restore"
            param("dotNetCoverage.dotCover.home.path", "%teamcity.tool.JetBrains.dotCover.CommandLineTools.DEFAULT%")
        }
        msBuild {
            path = "BuildAll.csproj"
            toolsVersion = MSBuildStep.MSBuildToolsVersion.V15_0
            param("dotNetCoverage.dotCover.home.path", "%teamcity.tool.JetBrains.dotCover.CommandLineTools.DEFAULT%")
        }
    }

    triggers {
        vcs {
        }
    }
})
