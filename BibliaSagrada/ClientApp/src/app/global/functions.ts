export function BodyEncode<T>(values: T): string {
    return Object.keys(values)
        .map(key => encodeURIComponent(key) + '=' + encodeURIComponent(values[key]))
        .join('&');
}
