private string GenerateJSONWebToken()
{
  var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond007"));
  var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

  var token = new JwtSecurityToken(
  issuer: "https://www.yogihosting.com",
  audience: "https://www.yogihosting.com",
  expires: DateTime.Now.AddHours(3),
  signingCredentials: credentials
  );

return new JwtSecurityTokenHandler().WriteToken(token);
}

private void SetJWTCookie(string token)
{
  var cookieOptions = new CookieOptions
  {
    HttpOnly = true,
    Expires = DateTime.UtcNow.AddHours(3),
  };
  Response.Cookies.Append("jwtCookie", token, cookieOptions);
}