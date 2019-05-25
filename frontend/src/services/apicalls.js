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

const WeeklyVisitsData = [
  { week: 1, visits: 40 },
  { week: 2, visits: 50 },
  { week: 3, visits: 35 },
  { week: 4, visits: 70 },
  { week: 5, visits: 55 },
  { week: 6, visits: 42 }
];

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

function getIsSignedIn(email) {
  return new Promise((res, rej) => {
    setTimeout(() => {
      return res(email === "lbutche3@wvup.edu");
    }, 1000);
  });
}

function getWeeklyVisitsData({ startDate, endDate }) {
  console.log(startDate, endDate);
  return new Promise((res, rej) => {
    setTimeout(() => res(WeeklyVisitsData), 1000);
  });
}

export { getStudentInfo, getReasons, getIsSignedIn, getWeeklyVisitsData };
