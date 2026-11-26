# Changelog

## 5.0.0

### Breaking changes

- The root namespace changed from `OpenDotaDotNet` to `OpenDota.NET`. Update imports for the client, models, endpoints, enums and converters. The league namespace also changed from `Routes.League` to `Routes.Leagues`.
- `Match.League` uses the shared `Routes.Leagues.Models.League` type. Its ticket, banner and tier may be null.
- `GetParsedMatchesAsync` returns a list and uses the optional `lessThanMatchId` cursor.
- Game mode, lobby type and lane role fields and filters use numeric enums. Unknown numeric values are preserved.
- `OpenDotaSettings.ApiKey` and `Proxy` are instance properties. Query arguments are encoded by the client; pass raw SQL to Explorer.
- `GetHeroItemPopularityAsync` returns a single object. `GetPublicMatchesAsync` uses `minRank` and `maxRank`. `GetConstantsAsync(Constant)` returns `JsonNode`.
- Several fields are nullable where the API returns null, including player match, live player, professional player and record fields. `TeamScenariosQueryParams` contains strings.
- Optional player filters are omitted unless explicitly set.
- Removed the public numeric and string-enum converters in favor of `System.Text.Json`. Invalid numeric values now throw `JsonException` instead of returning sentinel values or null. String enum members use their API names when serialized.

### Added and corrected

- Added top-player and league endpoints, endpoint URLs and a Microsoft dependency injection package.
- API keys work for GET and POST. Parse request responses use the configured JSON options.
- Added contract tests and split integration and dependency-injection tests into separate projects.
