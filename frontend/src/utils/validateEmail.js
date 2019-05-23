// Email regex credit to https://www.regextester.com/94044

const EmailRegex = RegExp(
  /^[a-zA-Z0-9_.+-]+@(?:(?:[a-zA-Z0-9-]+\.)?[a-zA-Z]+\.)?(wvup)\.edu$/
);

function checkEmail(email) {
  return EmailRegex.test(email);
}

export default checkEmail;
