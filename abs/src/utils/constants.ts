export const years = () => {
  let _years = [];

  for (let i = 1970; i <= 2050; i++) {
    _years.push(i);
  }

  return _years;
};

export const months = () => {
  let _months = [];

  for (let i = 1; i <= 12; i++) {
    _months.push(i);
  }

  return _months;
};

export const days = () => {
  let _days = [];

  for (let i = 1; i <= 31; i++) {
    _days.push(i);
  }

  return _days;
};

export const rowsList = (number = 10) => {
  let _rows = [];

  for (let i = 1; i <= number; i++) {
    _rows.push(i);
  }

  return _rows;
};

export const colsList = () => {
  let _cols = [];

  for (let i = 1; i <= 6; i++) {
    _cols.push(i);
  }

  return _cols;
};

export const colsListNumber = (number: number) => {
  let _cols = [];

  for (let i = 0; i < number; i++) {
    _cols.push(String.fromCharCode(65 + i));
  }

  return _cols;
};
