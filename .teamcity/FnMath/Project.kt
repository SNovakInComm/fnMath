package FnMath

import FnMath.buildTypes.*
import FnMath.vcsRoots.*
import FnMath.vcsRoots.FnMath_HttpsGithubComSNovakInCommFnMathGitRefsHeadsMaster
import jetbrains.buildServer.configs.kotlin.v2017_2.*
import jetbrains.buildServer.configs.kotlin.v2017_2.Project
import jetbrains.buildServer.configs.kotlin.v2017_2.projectFeatures.VersionedSettings
import jetbrains.buildServer.configs.kotlin.v2017_2.projectFeatures.versionedSettings

object Project : Project({
    uuid = "738b99a4-7757-44d6-be13-d2195ff57c47"
    id = "FnMath"
    parentId = "_Root"
    name = "FnMath"

    vcsRoot(FnMath_HttpsGithubComSNovakInCommFnMathGitRefsHeadsMaster)

    buildType(FnMath_Build)

    features {
        versionedSettings {
            id = "PROJECT_EXT_3"
            mode = VersionedSettings.Mode.ENABLED
            buildSettingsMode = VersionedSettings.BuildSettingsMode.PREFER_SETTINGS_FROM_VCS
            rootExtId = FnMath_HttpsGithubComSNovakInCommFnMathGitRefsHeadsMaster.id
            showChanges = false
            settingsFormat = VersionedSettings.Format.KOTLIN
            storeSecureParamsOutsideOfVcs = true
        }
    }
})
