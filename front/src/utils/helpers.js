const setDelay = (timer) => {
  return new Promise((resolve) =>
    setTimeout(() => {
      resolve();
    }, timer)
  );
};

export { setDelay };
