# Cake.Pnpm

[![standard-readme compliant][]][standard-readme]
[![All Contributors][all-contributorsimage]](#contributors)
[![Build][githubimage]][githubbuild]
[![CodeQL][githubcodeanalysisimage]][githubcodeanalysis]

Makes [pnpm](https://pnpm.io/) available as a tool in [Cake](https://cakebuild.net/)

## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Maintainer](#maintainer)
- [Contributing](#contributing)
  - [Contributors](#contributors)
- [License](#license)

## Install

```cs
#addin nuget:?package=Cake.Pnpm
```

## Usage

```cs
#addin nuget:?package=Cake.Pnpm

Task("MyTask").Does(() => {
  Pnpm();
});
```

## Maintainer

[Aleksandr Ivanov @aivanov-oneinc][maintainer]

## Contributing

Cake.Pnpm follows the [Contributor Covenant][contrib-covenant] Code of Conduct.

We accept Pull Requests.
Please see [the contributing file][contributing] for how to contribute to Cake.Pnpm.

Small note: If editing the Readme, please conform to the [standard-readme][] specification.

This project follows the [all-contributors][] specification. Contributions of any kind welcome!

### Contributors

Thanks goes to these wonderful people ([emoji key][emoji-key]):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore -->
<!-- ALL-CONTRIBUTORS-LIST:END -->

## License

[MIT License © Potapy4][license]

[all-contributors]: https://github.com/all-contributors/all-contributors
[all-contributorsimage]: https://img.shields.io/github/all-contributors/cake-contrib/Cake.ESLint.svg?color=orange&style=flat-square
[githubbuild]: https://github.com/cake-contrib/Cake.Pnpm/actions/workflows/build.yml?query=branch%3Amaster
[githubimage]: https://github.com/cake-contrib/Cake.Pnpm/actions/workflows/build.yml/badge.svg?branch=master
[githubcodeanalysis]: https://github.com/cake-contrib/Cake.Pnpm/actions/workflows/codeql-analysis.yml?query=branch%3Amaster
[githubcodeanalysisimage]: https://github.com/cake-contrib/Cake.Pnpm/actions/workflows/codeql-analysis.yml/badge.svg?branch=master
[contrib-covenant]: https://www.contributor-covenant.org/version/1/4/code-of-conduct
[contributing]: CONTRIBUTING.md
[license]: LICENSE.txt
[maintainer]: https://github.com/aivanov-oneinc
[standard-readme]: https://github.com/RichardLitt/standard-readme
[standard-readme compliant]: https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square
