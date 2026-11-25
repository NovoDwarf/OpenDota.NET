# Changelog

## 5.0.0 (unreleased) — Breaking Changes

This release is planned as the next major release after 4.0.0. Release versions are taken from tags such as `v5.0.0`; this entry does not publish a release or create a tag.

### Breaking changes

- Game mode, lobby type, and lane role fields and filters use numeric enum types. Cast unknown numeric values when needed; numeric JSON values are preserved.

- `OpenDotaSettings.ApiKey` and `Proxy` are now configurable instance properties; keys are sent with GET and POST requests.
- `GetHeroItemPopularityAsync` returns a single `HeroItemPopularity` instead of a list.
- `GetPublicMatchesAsync` uses `minRank` and `maxRank` instead of MMR ordering parameters.
- `GetConstantsAsync(Constant)` returns `JsonNode`, which may contain an object or an array.
- `PublicMatch.RadiantWin`, `PlayerPro.IsLocked`, `IsPro`, `TeamId`, and `FantasyRole` are nullable.
- `PlayerEndpointParameters.Significant`, `Having`, and `Sort` are optional and omitted unless explicitly set.
- Query arguments are encoded by the client; pass raw SQL to Explorer instead of percent-encoded SQL.

### Added and corrected

- Added top players and league detail, matches, match IDs, and teams endpoints.
- `OpenDotaApi` implements `IDisposable`. Search accepts both `sml` and the documented `similarity` response field; health usage exposes `Limit`.
- Added offline request and deserialization contract tests.

