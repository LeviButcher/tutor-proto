import styled from "styled-components";

const Form = styled.form`
  padding: 2rem;
  background: ${props => props.color || "#ccc"};

  & > div {
    margin: 20px;
  }
`;

export default Form;
