# Cake.Pnpm

[![standard-readme compliant][]][standard-readme]
[![All Contributors][all-contributorsimage]](#contributors)
[![Build][githubimage]][githubbuild]
[![Codecov Report][codecovimage]][codecov]
[![NuGet package][nugetimage]][nuget]

Makes [pnpm](https://pnpm.io/) available as a tool in Cake.

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

[Potapy4 @Potapy4][maintainer]

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
[appveyor]: https://ci.appveyor.com/project/nikita potapenko/cake-pnpm
[appveyorimage]: https://img.shields.io/appveyor/ci/nikita potapenko/cake-pnpm.svg?logo=appveyor&style=flat-square
[codecov]: https://codecov.io/gh/Nikita Potapenko/Cake.Pnpm
[codecovimage]: https://img.shields.io/codecov/c/github/Nikita Potapenko/Cake.Pnpm.svg?logo=codecov&style=flat-square
[contrib-covenant]: https://www.contributor-covenant.org/version/1/4/code-of-conduct
[contributing]: CONTRIBUTING.md
[emoji-key]: https://allcontributors.org/docs/en/emoji-key
[maintainer]: https://github.com/Potapy4
[nuget]: https://nuget.org/packages/Cake.Pnpm
[nugetimage]: https://img.shields.io/nuget/v/Cake.Pnpm.svg?logo=nuget&style=flat-square
[license]: LICENSE
[standard-readme]: https://github.com/RichardLitt/standard-readme
[standard-readme compliant]: https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square
[travis]: https://travis-ci.org/Nikita Potapenko/Cake.Pnpm
[travisimage]: https://img.shields.io/travis/Nikita Potapenko/Cake.Pnpm.svg?logo=travis&style=flat-square
