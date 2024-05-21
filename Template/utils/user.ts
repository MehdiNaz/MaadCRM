/**
 * @returns true if the user is logged in, false otherwise
 */
export function is_logged_in(): boolean {
    return !!localStorage.getItem("token");
}