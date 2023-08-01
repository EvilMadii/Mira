export const GetBaseURL = function () {
    const Environment = process.env.ENVIRONMENT
    if (Environment === "PROD")
        return process.env.API_URL
    else if (Environment === "DEV")
        return "https://localhost:5264/api/v1"
    else
        throw new Error("please set ENVIRONMENT to  DEV or PROD Into the .env file")
}