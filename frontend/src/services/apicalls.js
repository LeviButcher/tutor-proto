const Reasons = [{ name: "Tutoring", id: 2 }, { name: "Computer Use", id: 1 }];
const Courses = [
  { courseName: "CS121", CRN: "13224" },
  { courseName: "CS420", CRN: "34561" },
  { courseName: "PHIL101", CRN: "35465" },
  { courseName: "HIST111", CRN: "64987" }
];
const user = {
  email: "lbutche3@wvup.edu",
  courses: Courses
};

function getStudentInfo(email) {
  return new Promise((res, rej) => {
    setTimeout(() => {
      if (email === user.email) {
        return res(user);
      }
      return rej("User not found");
    }, 1000);
  });
}

function getReasons() {
  return new Promise((res, rej) => {
    setTimeout(() => {
      return res(Reasons);
    }, 1000);
  });
}

export { getStudentInfo, getReasons };
