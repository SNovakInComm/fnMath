package FnMath

import FnMath.buildTypes.*
import FnMath.vcsRoots.*
import jetbrains.buildServer.configs.kotlin.v2017_2.*
import jetbrains.buildServer.configs.kotlin.v2017_2.Project

object Project : Project({
    uuid = "738b99a4-7757-44d6-be13-d2195ff57c47"
    id = "FnMath"
    parentId = "_Root"
    name = "FnMath"

    vcsRoot(FnMath_HttpsGithubComSNovakInCommFnMathGitRefsHeadsMaster)

    buildType(FnMath_Build)
})
